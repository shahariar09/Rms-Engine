using Rms.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Entities.Permissions
{
    [Table("RMS_PERMISSION_MODULE")]
    public class PermissionModule : AuditableEntity, IEntity, IDeletable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<PermissionFeature> PermissionFeatures { get; set; }
        public int? ClientId { get; set; }
        public bool IsSoftDelete { get; set; }

        public bool Delete()
        {
            return IsSoftDelete = true;
        }
    }
}
