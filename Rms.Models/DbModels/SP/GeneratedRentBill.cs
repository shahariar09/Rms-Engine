using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.DbModels.SP
{
    public class GeneratedRentBill
    {
        public string? MonthsName { get; set; }
        public string? YearName { get; set; }
        public decimal? GassBill { get; set; }
        public decimal? WaterBill { get; set; }
        public decimal? OtherBill { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? Duedate { get; set; }
        public decimal? recentReading { get; set; }
        public decimal? NowReading { get; set; }
        public decimal? ResidentialEBrate { get; set; }
        public decimal? CommercialEBrate { get; set; }
        public decimal? RentAmount { get; set; }
        public decimal? ServiceCharge { get; set; }
    }
}
