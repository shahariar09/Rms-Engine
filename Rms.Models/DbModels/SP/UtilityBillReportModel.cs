using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.DbModels.SP
{
    public class UtilityBillReportModel
    {
        public string BillNo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime LastPayDate { get; set; }
        public string AccountNo { get; set; }
        public string CustomerName { get; set; }
        public string? Shop { get; set; }
        public decimal? AreaSFT { get; set; }
        public decimal? ServicebillRateSrf { get; set; }
        public decimal? Total { get; set; }
        public decimal? PreviousDueAmount { get; set; }
        public int? ArrearPercentage { get; set; }
        public decimal ArrearAmount { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? TowerBillAmount { get; set; }
        public decimal? GeneratorBillAmount { get; set; }
        public decimal? ParkingBillAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? ForMonthOf { get; set; }
    }
}
