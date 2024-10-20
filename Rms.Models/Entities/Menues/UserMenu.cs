using Rms.Models.Common;
using Rms.Models.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Entities.Menues
{
    [Table("RMS_USER_MENU")]
    public class UserMenu : AuditableEntity
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [NotMapped]
        public User User { get; set; }
        public long MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public bool IsSoftDelete { get; set; }

        public bool Delete()
        {
            return IsSoftDelete = true;
        }
    }
}
