using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class update_VW_RentAndUtilityBillSummary_add_arrear_previousDue_totalAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            Create or Alter VIEW [dbo].[VW_RentAndUtilityBillSummary] AS
            SELECT
                rub.*,
                (select max(PaidAmount) from RMS_BILL_COLLECTION bc where rub.BillNo=bc.BillNo) PaidAmount
            FROM 
                RMS_RENT_AND_UTILITY_BILL rub
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
