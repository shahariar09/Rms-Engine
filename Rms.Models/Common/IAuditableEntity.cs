using System;
using System.Collections.Generic;
using System.Text;

namespace Rms.Models.Common
{
    public interface IAuditableEntity
    {
        public long? CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
