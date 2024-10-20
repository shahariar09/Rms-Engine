using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Request.Setup
{
    public class CustomerActiveDateUpdateDto
    {
        public int CustomerId { get; set; }
        public string? ContactName { get; set; }
        public DateTime? RentActiveDate { get; set; }
        public decimal? AdvanceRentAmount { get; set; }
        public decimal? DueAmount { get; set; }
    }
}
