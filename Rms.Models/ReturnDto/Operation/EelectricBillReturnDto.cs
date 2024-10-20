using Rms.Models.Enums;

namespace Rms.Models.ReturnDto.Operation
{
    public class EelectricBillReturnDto
    {
        public long Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContactName { get; set; }
        
        public string BillNo { get; set; }
        public EletricBillType EletricBillType { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? PresentReading { get; set; }
        public decimal? ConsumedUnit { get; set; }
        public decimal? ElectricCharge { get; set; }
        public decimal? DemandCharge { get; set; }
        public decimal? ServiceCharge { get; set; }
        public decimal? PrincipalAmount { get; set; }
        public decimal? DutyOnKhw { get; set; }
        public decimal? ShopServiceCharge { get; set; }
        public decimal? Vat { get; set; }
        public decimal? BillMonthTotal { get; set; }
        public bool BillPayStatus { get; set; }
        public DateTime? BillPayDate { get; set; }
    }
}
