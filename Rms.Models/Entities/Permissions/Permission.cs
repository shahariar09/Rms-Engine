using Rms.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Entities.Permissions
{
    [Table("RMS_PERMISSION")]
    public class Permission : AuditableEntity, IEntity, IDeletable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long PermissionFeatureId { get; set; }
        public PermissionFeature PermissionFeature { get; set; }
        public int? ClientId { get; set; }
        public bool IsSoftDelete { get; set; }
        public bool HasLimit { get; set; }
        public bool Delete()
        {
            return IsSoftDelete = true;
        }
    }
}
