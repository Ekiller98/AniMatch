using Microsoft.AspNetCore.Identity;

namespace AniMatch.Persistence.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
