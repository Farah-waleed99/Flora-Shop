using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Master.Models.ViewModels
{
    public class CategoryProduct
    {
        public List<Product> Products{ get; set; }

        public List<Category> Categories { get; set; }
    }
}
