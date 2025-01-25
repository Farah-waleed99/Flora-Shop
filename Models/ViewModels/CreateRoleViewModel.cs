using System.ComponentModel.DataAnnotations;

namespace Master.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
