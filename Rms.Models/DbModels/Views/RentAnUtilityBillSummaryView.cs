using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.DbModels.Views
{
    public class RentAnUtilityBillSummaryView
    {
        public long Id { get; set; }
        public int CustomerId { get; set; }
        public string? BillNo { get; set; }
        public string? CustomerName { get; set; }
        public string? ContactName { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal? TotalBillAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool BillCollectStatus { get; set; }
        public long? CreatedById { get; set; }  // Nullable if it may not always have a value
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedById { get; set; }  // Nullable if it may not always have a value
        public DateTime? UpdatedOn { get; set; }  // Nullable if it may not always be updated
        public long? DeletedById { get; set; }  // Nullable if not always deleted
        public DateTime? DeletedOn { get; set; }  // Nullable for soft deletes
        public bool IsSoftDelete { get; set; }
        public decimal? PaidAmount { get; set; }
    }
}
