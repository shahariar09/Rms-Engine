using Rms.Models.Common;
using Rms.Models.Entities.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Entities.Operation.RentBill
{
    [Table("RMS_RENT_AND_UTILITY_BILL_DETAIL")]
    public class RentAndUtilityBillDetail:AuditableEntity
    {
        public long Id { get; set; }
        public RentAndUtilityBill RentAndUtilityBill { get; set; }
        public long RentAndUtilityBillId { get; set; }
        public string MonthName { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public decimal? RentAmount { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? WaterBill { get; set; }
        public decimal? OtherBill { get; set; }
        public decimal? GasBillAmount { get; set; }
    }
}
