using System.ComponentModel.DataAnnotations;

namespace ProductsManager.Application.Model
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(300, ErrorMessage = "Name can have a maximum of 300 characters.")]
        public required string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int Stocke { get; set; }
    }
}