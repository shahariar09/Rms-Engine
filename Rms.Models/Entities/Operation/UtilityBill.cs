using Rms.Models.Entities.Setup;
using Rms.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Entities.Operation
{
    [Table("RMS_UTILITY_BILL")]
    public class UtilityBill
    {
        public long Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string BillNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal ServiceBillAreaSFT { get; set; }
        public decimal ServiceBillRateSrf { get; set; }
        public decimal ServiceBillTotalAmount { get; set; }
        public decimal? TowerBillAmount{ get; set; }
        public decimal? GeneratorBillAmount{ get; set; }
        public decimal? ParkingBillAmount{ get; set; }
        public decimal? TotalBillAmount { get; set; }
        public decimal TotalAmount{ get; set; }
        public bool BillPayStatus { get; set; }
        public DateTime? BillPayDate { get; set; }
        public decimal? PreviousDueAmount { get; set; }
        public decimal? ArrearAmount { get; set; }

    }
}
