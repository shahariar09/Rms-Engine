using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class Create_SP_UtilityBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            Create Or Alter PROCEDURE SP_UtilityBill
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

                    (
                        SELECT SUM(bc.DueAmount) AS TotalDueAmount
                        FROM RMS_UTILITY_BILL ub
                        LEFT JOIN RMS_BILL_COLLECTION bc ON ub.BillNo = bc.BillNo
                        WHERE ub.CustomerId = @CustomerId
                        AND bc.BillType = 3
                        AND YEAR(ub.IssueDate) = @Year
                        AND MONTH(ub.IssueDate) < @Month
                    ) AS PreviousDueAmount,

                    5 AS ArrearPercentage,

                    ROUND(
                        COALESCE(
                            (
                                SELECT CASE 
                                    WHEN (
                                        SELECT TOP 1 bc.CollectionDate 
                                        FROM RMS_BILL_COLLECTION bc 
                                        WHERE bc.BillNo = ub.BillNo 
                                        AND bc.CustomerId = c.Id 
                                        AND bc.BillType = 1
                                        ORDER BY bc.CollectionDate ASC
                                    ) > ub.DueDate 
                                    THEN ub.TotalAmount * 0.05 
                                    ELSE 0 
                                END
                            ), 0
                        ), 2
                    ) AS ArrearAmount,

                    (
                        (c.AreaSFT * c.ServicebillRateSrf) +
                        (
                            SELECT SUM(bc.DueAmount) AS TotalDueAmount
                            FROM RMS_UTILITY_BILL ub
                            LEFT JOIN RMS_BILL_COLLECTION bc ON ub.BillNo = bc.BillNo
                            WHERE ub.CustomerId = @CustomerId
                            AND bc.BillType = 3
                            AND YEAR(ub.IssueDate) = @Year
                            AND MONTH(ub.IssueDate) < @Month
                        ) +
                        ROUND(
                            COALESCE(
                                (
                                    SELECT CASE 
                                        WHEN (
                                            SELECT TOP 1 bc.CollectionDate 
                                            FROM RMS_BILL_COLLECTION bc 
                                            WHERE bc.BillNo = ub.BillNo 
                                            AND bc.CustomerId = c.Id 
                                            AND bc.BillType = 1
                                            ORDER BY bc.CollectionDate ASC
                                        ) > ub.DueDate 
                                        THEN ub.TotalAmount * 0.05 
                                        ELSE 0 
                                    END
                                ), 0
                            ), 2
                        )
                    ) AS GrandTotal,

                    ub.TowerBillAmount,
                    ub.GeneratorBillAmount,
                    ub.ParkingBillAmount
                FROM RMS_UTILITY_BILL ub
                LEFT JOIN RMS_BILL_COLLECTION bc ON ub.BillNo = bc.BillNo
                LEFT JOIN RMS_CUSTOMER c ON ub.CustomerId = c.Id
                LEFT JOIN RMS_COMPLEX cmplx ON c.ComplexId = cmplx.Id
                WHERE ub.CustomerId = @CustomerId
	            AND ub.IssueDate >= @StartDate
	            AND ub.IssueDate <= @EndDate
            )
            SELECT 
                CTE.*,
                (GrandTotal + CTE.TowerBillAmount + CTE.GeneratorBillAmount + CTE.ParkingBillAmount) AS TotalAmount
            FROM CTE;

            End


            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
