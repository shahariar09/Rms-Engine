using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class create_VW_ElectricBillSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            Create Or Alter VIEW [dbo].[VW_ElectricBillSummary] AS
                SELECT
                    eb.[Id],
                    eb.[CustomerId],
                    eb.[BillNo],
                    eb.[EletricBillType],
                    eb.[IssueDate],
                    eb.[DueDate],
                    eb.[PresentReading],
                    eb.[ConsumedUnit],
                    eb.[ElectricCharge],
                    eb.[DemandCharge],
                    eb.[ServiceCharge],
                    eb.[PrincipalAmount],
                    eb.[DutyOnKhw],
                    eb.[ShopServiceCharge],
                    eb.[Vat],
                    eb.[BillMonthTotal],
                    eb.[BillPayStatus],
                    eb.[BillPayDate],
                    (select max(PaidAmount) from RMS_BILL_COLLECTION bc 
					where eb.BillNo=bc.BillNo
					and eb.CustomerId=bc.CustomerId
					) PaidAmount
                FROM 
                    RMS_ELECTRIC_BILL eb
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
