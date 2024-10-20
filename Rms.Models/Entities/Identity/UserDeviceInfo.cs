using Rms.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rms.Models.Entities.Identity
{
    [Table("RMS_USER_DEVICE_INFO")]
    public class UserDeviceInfo :  AuditableEntity, IEntity , IDeletable
    {
        public long Id { get; set; }
        public int? ClientId { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public bool IsInActive { get; set; } 
        public string Remarks { get; set; }
        public string DeviceInfo { get; set; }
        public bool IsSoftDelete { get; set; }
        public bool Delete()
        {
            return IsSoftDelete = true;
        }

    }
}
