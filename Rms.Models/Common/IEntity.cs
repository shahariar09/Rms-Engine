using System;
using System.Collections.Generic;
using System.Text;

namespace Rms.Models.Common
{
    public interface IEntity
    {
        public long Id { get; set; }
        public int? ClientId { get; set; }
    }
}
