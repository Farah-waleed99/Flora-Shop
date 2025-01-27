using System.ComponentModel.DataAnnotations.Schema;

namespace Master.Models
{
    public class Product
    {

        public string Name { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string? Image { get; set; }
        [NotMapped] // This will prevent EF from mapping this property to the database
        public IFormFile ImageFile { get; set; } // For the uploaded file
     
     
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public string SellerName { get; set; }
        public string SellerPhone { get; set; }

        public int Stock { get; set; }


    }
}
