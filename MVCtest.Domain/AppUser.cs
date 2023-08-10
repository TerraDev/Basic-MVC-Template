using Microsoft.AspNetCore.Identity;

namespace MVCtest.Domain
{
    public class AppUser : IdentityUser
    {
        public string? Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
    }
}