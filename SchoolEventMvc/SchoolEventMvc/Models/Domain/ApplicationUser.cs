using Microsoft.AspNetCore.Identity;

namespace SchoolEventMvc.Models.Domain
{
    public class ApplicationUser :IdentityUser
    {
        public string Name { get; set; }
    }
}
