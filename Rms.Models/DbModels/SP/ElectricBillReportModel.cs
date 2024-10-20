using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.DbModels.SP
{
    public class ElectricBillReportModel
    {
        public string? BillNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public string? AccountNo { get; set; }
        public DateTime? LastPayDate { get; set; }
        public string? CustomerName { get; set; }
        public string? Shop { get; set; }
        public string? ElectricMetterNo { get; set; }
        public decimal PresentReading { get; set; }
        public DateTime PresentReadingDate { get; set; }
        public decimal PreviousReading { get; set; }
        public decimal PreviousDueAmount { get; set; }
        public int ArrearPercentage { get; set; }
        public decimal ArrearAmount { get; set; }


        public DateTime? PreviousReadingDate { get; set; }
        public decimal Consumption { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ConsumptionPrice { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal DemandCharge { get; set; }
        public decimal Total { get; set; }
        public decimal VatPercentage { get; set; }
        public decimal VatAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public string? ForMonthOf { get; set; }
    }
}
