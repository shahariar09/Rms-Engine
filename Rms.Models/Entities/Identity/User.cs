using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Rms.Models.Common;
using Rms.Models.Entities.Setup;


namespace Rms.Models.Entities.Identity
{

    public class User : IdentityUser<int>, IAuditableEntity, IDeletable
    {
   
        //public int? ComplexId { get; set; }
        //public Complex? Complex { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool IsSoftDelete { get; set; }
        public string? PhoneNumber { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public bool Delete()
        {
            return IsSoftDelete = true;
        }
    }
}
