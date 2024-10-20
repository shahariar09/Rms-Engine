namespace Rms.Models.DbModels.Views
{
    public class VW_Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Code { get; set; }
        public int PurchaseUnitId { get; set; }
        public string? PurchaseUnitName { get; set; }
        public int SaleUnitId { get; set; }
        public string? SaleUnitName { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal? VAT { get; set; }
        public bool IsEnable { get; set; }
        public string? ProductImageUrl { get; set; }
        public string? Details { get; set; }
    }
}
