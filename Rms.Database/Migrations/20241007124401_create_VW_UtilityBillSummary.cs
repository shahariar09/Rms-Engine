using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class create_VW_UtilityBillSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            Create or ALTER VIEW VW_UtilityBillSummary AS
                SELECT
                    ub.Id,
                    ub.CustomerId,
					c.Name CustomerName,
                    ub.BillNo,
                    ub.IssueDate,
                    ub.DueDate,
					ub.TotalAmount,
                    ub.BillPayStatus,
                    ub.BillPayDate,
                    (select max(PaidAmount) from RMS_BILL_COLLECTION bc where ub.BillNo=bc.BillNo) PaidAmount
                FROM 
                    RMS_UTILITY_BILL ub
					left join RMS_CUSTOMER c on ub.CustomerId=c.Id
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
