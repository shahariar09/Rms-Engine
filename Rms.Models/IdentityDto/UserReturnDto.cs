using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.IdentityDto
{
    public class UserReturnDto
    {
        public int Id { get; set; }
        public int? ComplexId { get; set; }
        public string UserName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool IsSoftDelete { get; set; }
        public string? PhoneNumber { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int Sl { get; set; }
    }
}
