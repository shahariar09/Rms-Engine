using Rms.Models.Entities.Operation.RentBill;
using Rms.Models.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Request.Operation.RentBill
{
    public class RentAndUtilityBillCreateDto
    {
        public long? Id { get; set; }
        public int CustomerId { get; set; }
        public string? BillNo { get; set; }
        public string CustomerName { get; set; }
        public string ContactName { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? TotalBillAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool BillCollectStatus { get; set; }
        public decimal? PreviousDueAmount { get; set; }
        public decimal? ArrearAmount { get; set; }
        public ICollection<RentAndUtilityBillDetailCreateDto> RentAndUtilityBillDetails { get; set; }
    }
}
