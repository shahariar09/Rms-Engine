using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.DbModels.Views
{
    public class CusotmerWithServiceBillView
    {
        public int? Id { get; set; }
        public int? ComplexId { get; set; }
        public string? Name { get; set; }
        public string? FatherName { get; set; }
        public string? Address { get; set; }
        public string? MobileNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NID { get; set; }
        public string? Email { get; set; }
        public int? CustomerType { get; set; }
        public DateTime? DOB { get; set; }
        public string? ContactName { get; set; }
        public int? LevelNo { get; set; }
        public decimal? FixElectricBillAmount { get; set; }
        public int? ElectricBillType { get; set; }
        public string? ElectricMetterNo { get; set; }
        public decimal? ElectricMetterLastReading { get; set; }
        public DateTime? ElectricMetterLastReadingDate { get; set; }
        public bool? Discontinued { get; set; }
        public decimal? OpeningReading { get; set; }
        public decimal? RentAmount { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? WaterBill { get; set; }
        public decimal? OtherBill { get; set; }
        public int? GassBillType { get; set; }
        public decimal? GassBillUnitPrice { get; set; }
        public int? GasStoveType { get; set; }
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
        public bool IsGasBillRequired { get; set; }
        public bool IsRentFixed { get; set; }
        public bool IsFixElectricBill { get; set; }
        public decimal? AreaSFT { get; set; }
        public decimal? RateSrf { get; set; }
        public decimal? DueAmount { get; set; }
        public int? MotorcycleQuantity { get; set; }
        public int? CarQuantity { get; set; }
        public bool? IsWaterBillRequired { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? DeletedById { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool? IsSoftDelete { get; set; }
        public DateTime? DeedEndDate { get; set; }
        public DateTime? DeedStartDate { get; set; }
        public decimal? SecurityDeposit { get; set; }
        public decimal? ServiceBillRateSrf { get; set; }
        public decimal? ServiceBillDueAmount { get; set; }
    }
}
