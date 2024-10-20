using Rms.Models.Common;
using Rms.Models.Entities.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Entities.Operation
{
    [Table("RMS_WATER_BILL")]
    public class WaterBill : AuditableEntity
    {
        public long Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public string BillNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? Vat { get; set; }
        public decimal? BillMonthTotal { get; set; }
        public bool BillGenerateStatus { get; set; }
        public bool BillPayStatus { get; set; }
        public DateTime? BillPayDate { get; set; }

     
    }
}
