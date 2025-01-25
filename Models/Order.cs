using System.ComponentModel.DataAnnotations;
using Master.Models.CommonProp;
using Master.Models.ViewModels;

namespace Master.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserPhoneNumber { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }
        public ApplicationUser User { get; set; }
       
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public decimal TotalAmount { get; set; }
        [DataType(DataType.MultilineText)]
        
        public OrderStatus Status { get; set; }
       
        public ICollection<OrderItem>? OrderItems { get; set; }


        public enum OrderStatus
        {
            Pending,
            Completed,
            Canceled
        }
    }

}

