using Rms.Models.Common;
using Rms.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Entities.Operation
{
    [Table("RMS_BILL_COLLECTION")]
    public class BillCollection : AuditableEntity
    {
        public long Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? CollectionDate { get; set; }
        public string BillNo { get; set; }
        public string CustomerId { get; set; }
        public BillType BillType { get; set; }
        public decimal? BillAmount { get; set; }
        public decimal? FineAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public PayType PayType { get; set; }
        public string? BankName { get; set; }
        public string? CheckNo { get; set; }
        public DateTime? CheckDate { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal? DueAmount { get; set; }
        public string? Note { get; set; }

    }
}
