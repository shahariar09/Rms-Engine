using Rms.Models.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Entities.Permissions
{
    [Table("RMS_ROLE_FEATURE_PERMISSION")]
    public class RoleFeaturePermission
    {
        public long Id { get; set; }
        public string UserRoles { get; set; }
        public long PermissionId { get; set; }
        public Permission Permission { get; set; }
        public long? Limit { get; set; }
        public int? ClientId { get; set; }
        public bool IsSoftDelete { get; set; }

        public bool Delete()
        {
            return IsSoftDelete = true;
        }
    }
}
