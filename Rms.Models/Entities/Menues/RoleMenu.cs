using Rms.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rms.Models.Entities.Menues
{
    [Table("RMS_ROLEMENU")]
    public class RoleMenu : AuditableEntity
    {
        public long Id { get; set; }
        public string Role { get; set; }
        public long MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public bool IsSoftDelete { get; set; }
        public int? ClientId { get; set; }

        public bool Delete()
        {
            return IsSoftDelete = true;
        }
    }
}
