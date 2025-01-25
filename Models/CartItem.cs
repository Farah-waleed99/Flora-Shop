using Master.Models;
using System.ComponentModel.DataAnnotations;

namespace Master.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        private int quantity;
        public Cart? Cart { get; set; }
        public int Quantity
        {
            get => quantity;
            set => quantity = value > 0 ? value : 1; // ا
        }

    }

}











