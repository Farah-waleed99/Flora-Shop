using System.ComponentModel.DataAnnotations;

namespace Master.Models.ViewModels
{
    public class RoleViewModel
    {

        [Required]
        public string RoleName { get; set; }
        public string RoleId { get; set; }
    }
}
