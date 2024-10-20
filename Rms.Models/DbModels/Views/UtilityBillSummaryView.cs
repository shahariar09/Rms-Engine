using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.DbModels.Views
{
    public class UtilityBillSummaryView
    {
        public long? Id { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string BillNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool BillPayStatus { get; set; }
        public DateTime? BillPayDate { get; set; }
        public decimal? PaidAmount { get; set; }
    }
}
