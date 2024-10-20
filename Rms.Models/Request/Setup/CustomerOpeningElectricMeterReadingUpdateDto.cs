using Rms.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Request.Setup
{
    public class CustomerOpeningElectricMeterReadingUpdateDto
    {
        public int CustomerId { get; set; }
        public string? ContactName { get; set; }
        public decimal? OpeningReading { get; set; }
        public DateTime? OpeningReadingDate { get; set; }
    }
}
