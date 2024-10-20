using Rms.Models.Entities.Operation.RentBill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Request.Operation.RentBill
{
    public class RentAndUtilityBillDetailCreateDto
    {
        public long? Id { get; set; }
        public long? RentAndUtilityBillId { get; set; }
        public string? MonthName { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public decimal? RentAmount { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? WaterBill { get; set; }
        public decimal? OtherBill { get; set; }
        public decimal? GasBillAmount { get; set; }
    }
}
