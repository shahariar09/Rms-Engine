using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.DbModels.SP
{
    public class RentAndUtilityBillReportModel
    {
        public string BillNo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime LastPayDate { get; set; }
        public string AccountNo { get; set; }
        public string CustomerName { get; set; }
        public string Shop { get; set; }
        public decimal AreaSFT { get; set; }
        public string FirstParty { get; set; }
        public string SecondParty { get; set; }
        public DateTime? DeedStartDate { get; set; }
        public DateTime? DeedEndDate { get; set; }
        public decimal? SecurityDeposit { get; set; }
        public decimal MonthlyRent { get; set; }
        public decimal? PreviousDueAmount { get; set; }
        public decimal? ArrearAmount { get; set; }
        public decimal? Total { get; set; }
        public string? ForMonthOf { get; set; }
    }
}
