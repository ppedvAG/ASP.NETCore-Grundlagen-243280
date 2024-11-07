using Microsoft.AspNetCore.Identity;

namespace DemoMvcApp.Data
{
    public class AppUser : IdentityUser
    {
        public string? FavoriteFood { get; set; }
    }
}
