using Rms.Models.Common;
using Rms.Models.Entities.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Entities.Operation.RentBill
{
    [Table("RMS_RENT_AND_UTILITY_BILL")]
    public class RentAndUtilityBill:AuditableEntity
    {
        public long Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string BillNo { get; set; }
        public string CustomerName { get; set; }
        public string ContactName { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? TotalBillAmount { get; set; }
        public bool BillCollectStatus { get; set; }
        public decimal? PreviousDueAmount { get; set; }
        public decimal? ArrearAmount { get; set; }
        public decimal? TotalAmount { get; set; }

        public ICollection<RentAndUtilityBillDetail> RentAndUtilityBillDetails { get; set; }
        
    }
}
