using Rms.Models.Common;
using Rms.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Entities.Setup
{
    [Table("RMS_CUSTOMER")]
    public class Customer: AuditableEntity
    {
        public int Id { get; set; }
        public int ComplexId { get; set; }
        public Complex Complex { get; set; }
        public string Name { get; set; }
        public string? FatherName { get; set; }
        public string? Address { get; set; }
        public string? MobileNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NID { get; set; }
        public string? Email { get; set; }
        public CustomerType CustomerType { get; set; }
        public DateTime? DOB { get; set; }
        public string? ContactName { get; set; }
        public int? LevelNo { get; set; }
        public decimal? FixElectricBillAmount { get; set; }
        public EletricBillType? ElectricBillType { get; set; }
        public string? ElectricMetterNo { get; set; }
        public decimal? ElectricMetterLastReading { get; set; }
        public DateTime? ElectricMetterLastReadingDate { get; set; }
        public bool Discontinued { get; set; }
        public decimal? OpeningReading { get; set; }
        public DateTime? OpeningReadingDate { get; set; }
        public decimal? RentAmount { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? WaterBill { get; set; }
        public decimal? OtherBill { get; set; }
        public GassBillType? GassBillType { get; set; }
        public decimal? GassBillUnitPrice { get; set; }
        public GasStoveType? GasStoveType { get; set; }
        public decimal? GasSingleStoveAmount { get; set; }
        public decimal? GasDoubleStoveAmount { get; set; }
        public DateTime? RentActiveDate { get; set; }
        public decimal? AdvanceRentAmount { get; set; }
        public decimal? GasOpeningReading { get; set; }
        public decimal? GasMeterLastReading { get; set; }
        public DateTime? GassMeterLastReadingDate { get; set; }
        public string? ImageUrl { get; set; }
        public string? NIDImageUrl { get; set; }
        public string? OtherDocumentUrl { get; set; }
        public bool isFixElectricBill { get; set; }
        public bool IsGasBillRequired { get; set; }
        public bool IsWaterBillRequired { get; set; }
        public decimal? AreaSFT { get; set; }
        public decimal? RateSrf { get; set; }
        public decimal? DueAmount { get; set; }
        public int? MotorcycleQuantity { get; set; }
        public int? CarQuantity { get; set; }
        public bool IsRentFixed { get; set; }
        public DateTime? DeedStartDate { get; set; }
        public DateTime? DeedEndDate { get; set; }
        public decimal? SecurityDeposit { get; set; }
        public decimal? ServiceBillRateSrf { get; set; }


    }
}
