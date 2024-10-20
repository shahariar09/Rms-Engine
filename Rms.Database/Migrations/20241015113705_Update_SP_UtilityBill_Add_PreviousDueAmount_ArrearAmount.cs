using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class Update_SP_UtilityBill_Add_PreviousDueAmount_ArrearAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            Create or ALTER PROCEDURE [dbo].[SP_UtilityBill]
	            @CustomerId NVARCHAR(50),
	            @Year INT,
	            @Month INT
	            AS
	            BEGIN

             DECLARE @StartDate DATE = DATEFROMPARTS(@Year, @Month, 1);
             DECLARE @EndDate DATE = EOMONTH(@StartDate);

             WITH CTE AS (
                SELECT 
                    ub.BillNo,
                    ub.IssueDate,
                    ub.DueDate AS LastPayDate,
                    CAST(cmplx.Name AS VARCHAR) + ' ' + CAST(c.LevelNo AS VARCHAR) AS AccountNo,
                    c.Name AS CustomerName,
                    c.ContactName AS Shop,
                    c.AreaSFT AreaSFT,
                    c.ServicebillRateSrf,
                    (c.AreaSFT * c.ServicebillRateSrf) AS Total,
		            FORMAT(DATEADD(MONTH, -1, ub.IssueDate), 'MMM-yy') AS ForMonthOf,

                     COALESCE(ub.PreviousDueAmount,0) PreviousDueAmount,
                     COALESCE(ub.ArrearAmount,0) ArrearAmount,


                    5 AS ArrearPercentage,

                    (
                        (c.AreaSFT * c.ServicebillRateSrf) +COALESCE(ub.PreviousDueAmount,0)+COALESCE(ub.ArrearAmount,0)
            
                    ) AS GrandTotal,

                    ub.TowerBillAmount,
                    ub.GeneratorBillAmount,
                    ub.ParkingBillAmount
                FROM RMS_UTILITY_BILL ub
                LEFT JOIN RMS_BILL_COLLECTION bc ON ub.BillNo = bc.BillNo
                LEFT JOIN RMS_CUSTOMER c ON ub.CustomerId = c.Id
                LEFT JOIN RMS_COMPLEX cmplx ON c.ComplexId = cmplx.Id
	            where ub.CustomerId = @CustomerId
	            AND ub.IssueDate >= @StartDate
	            AND ub.IssueDate <= @EndDate
            )
            SELECT 
                CTE.*,
                (GrandTotal + CTE.TowerBillAmount + CTE.GeneratorBillAmount + CTE.ParkingBillAmount) AS TotalAmount
            FROM CTE;

            End

            --EXEC SP_UtilityBill 7,2024,10
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
