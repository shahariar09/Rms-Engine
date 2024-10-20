using Microsoft.AspNetCore.Identity;
using Rms.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rms.Models.Entities.Identity
{
    public class UserRole : IdentityUserRole<int>, IDeletable
    {
        public bool IsSoftDelete { get; set; }
        [NotMapped]
        public  User User { get; set; }
        [NotMapped]
        public  Role Role { get; set; }
        public int ClientId { get; set; }

        public bool Delete()
        {
            return IsSoftDelete = true;
        }
    }
}
