using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RepititionMinimalAPI.Data;
using Scalar.AspNetCore;


namespace RepititionMinimalAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<MinimalAPIDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.MapGet("/lost-items", async (MinimalAPIDbContext db) =>
            
                await db.Case.ToListAsync()
            );

            app.MapGet("/lost-items/{id}", async (int id, MinimalAPIDbContext db) =>
            await db.Case.FindAsync(id)
                is Case lostItem ? Results.Ok(lostItem) : Results.NotFound()
            );


            app.MapPost("/lost-items", async (Case lostItem, MinimalAPIDbContext db) =>
            {
                db.Case.Add(lostItem);
                await db.SaveChangesAsync();

                return Results.Created($"/lostItem-items/{lostItem.Id}", lostItem);
            });

            app.MapPut("/lost-items/{id}", async (int id, Case lostItemInput, MinimalAPIDbContext db) =>
            {
                var lostItem = await db.Case.FindAsync(id);

                if (lostItem == null) return Results.NotFound();

                lostItem.Name = lostItemInput.Name;
                lostItem.LocationFound = lostItemInput.LocationFound;
                lostItem.DateFound = lostItemInput.DateFound;
                lostItem.IsClaimed = lostItemInput.IsClaimed;

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            app.MapDelete("/lost-items/{id}", async (int id, MinimalAPIDbContext db) =>
            {
                if (await db.Case.FindAsync(id) is Case lostItem)
                {
                    db.Case.Remove(lostItem);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }
               
                return Results.NotFound();

            });

            app.MapGet("/lost-items/search/", async ( string? location, bool? isClaimed, MinimalAPIDbContext db) =>
            {
                var Case = await db.Case.ToListAsync();
                if (!string.IsNullOrEmpty(location))
                {
                    Case = Case.Where(c => c.LocationFound == location).ToList();
                }
                if (isClaimed.HasValue)
                {
                    Case = Case.Where(c => c.IsClaimed == isClaimed.Value).ToList();
                }

                return Results.Ok(Case);
            });

            app.Run();


        }
    }
}
