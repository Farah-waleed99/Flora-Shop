using Microsoft.AspNetCore.Identity;

namespace Master.Models.ViewModels
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    
}
