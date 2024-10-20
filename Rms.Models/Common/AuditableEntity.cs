using System;
using System.Collections.Generic;
using System.Text;

namespace Rms.Models.Common
{
    public class AuditableEntity : IAuditableEntity
    {
        public long? CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? DeletedById { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsSoftDelete { get; set; }
    }
}
