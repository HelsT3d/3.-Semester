using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public double SalesPrice { get; set; }
        [Required]
        public double PurchasePrice { get; set; }
    }
}
