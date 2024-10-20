using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class create_VW_CusotmerWithServiceBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            Create Or Alter VIEW VW_CusotmerWithServiceBill AS
                select c.*,
                (select sum(DueAmount) from RMS_BILL_COLLECTION where BillNo=ub.BillNo) ServiceBillDueAmount 
                from RMS_CUSTOMER c
                LEFT JOIN [dbo].[RMS_UTILITY_BILL] ub on c.Id=ub.CustomerId
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
