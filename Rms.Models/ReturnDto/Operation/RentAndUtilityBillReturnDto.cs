using Rms.Models.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.ReturnDto.Operation
{
    public class RentAndUtilityBillReturnDto
    {
        public long Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string BillNo { get; set; }
        public string ContactName { get; set; }
        public DateTime? IssueDate { get; set; }
        public decimal? TotalBillAmount { get; set; }
        public bool BillCollectStatus { get; set; }
    }
}
