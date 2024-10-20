using Microsoft.AspNetCore.Identity;


namespace Rms.Models.Entities.Identity
{
    public class Role : IdentityRole<int>
    {
        public bool IsSoftDelete { get; set; }
    }
}
