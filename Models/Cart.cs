using Master.Models.ViewModels;

namespace Master.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public String? UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public decimal TotalAmount
        {
            get
            {
                return CartItems.Sum(item => item.Quantity * item.Product.Price);
            }
        }
    }
}
