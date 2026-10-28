using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class BookDto
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
    }
}
