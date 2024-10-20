using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class create_SP_GET_DUE_ARREAR_AMOUNT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR ALTER PROCEDURE SP_GET_DUE_ARREAR_AMOUNT
                    @CustomerId INT,
                    @BillDate DATETIME,
                    @BillType INT -- 1: Electric, 2: Rent, 3: Utility
                AS
                BEGIN
                    SET NOCOUNT ON;

                   WITH ElectricBillCTE AS (
                        SELECT 
                            eb.BillNo,
                            eb.CustomerId,
                            eb.BillMonthTotal,
                            bc.PreviousDueAmount AS PreviousDueAmount,
                            CASE 
                                WHEN (eb.BillMonthTotal - ISNULL(bc.TotalPaid, 0)) > 0 
                                     AND EXISTS (
                                        SELECT 1 
                                        FROM [RmsDb].[dbo].[RMS_BILL_COLLECTION] bc2 
                                        WHERE bc2.BillNo = eb.BillNo 
                                          AND bc2.CustomerId = eb.CustomerId 
                                          AND bc2.CollectionDate > eb.IssueDate
                                     )
                                THEN (eb.BillMonthTotal * 0.05) -- 5% arrear
                                ELSE 0
                            END AS ArrearAmount
                        FROM 
                            [RmsDb].[dbo].[RMS_ELECTRIC_BILL] eb
                        LEFT JOIN (
                            SELECT 
                                BillNo, 
                                CustomerId, 
                                SUM(DueAmount) PreviousDueAmount,
                                SUM(PaidAmount) AS TotalPaid
                            FROM 
                                [RmsDb].[dbo].[RMS_BILL_COLLECTION]
                            WHERE 
                                BillType = 1 -- BillType 1 for Electric
                            GROUP BY 
                                BillNo, CustomerId
                        ) bc 
                        ON eb.BillNo = bc.BillNo 
                        AND eb.CustomerId = bc.CustomerId
                        WHERE 
                            eb.CustomerId = @CustomerId
                            AND eb.IssueDate = (
                                SELECT MAX(IssueDate) 
                                FROM [RmsDb].[dbo].[RMS_ELECTRIC_BILL] 
                                WHERE CustomerId = @CustomerId 
                                AND IssueDate < @BillDate
                            )
                    ),
    
                    -- CTE for Rent Bill
                    RentBillCTE AS (
                        SELECT 
                            rb.BillNo,
                            rb.CustomerId,
                            rb.TotalBillAmount,
                            bc.PreviousDueAmount AS PreviousDueAmount,
                            CASE 
                                WHEN (rb.TotalBillAmount - ISNULL(bc.TotalPaid, 0)) > 0 
                                     AND EXISTS (
                                        SELECT 1 
                                        FROM [RmsDb].[dbo].[RMS_BILL_COLLECTION] bc2 
                                        WHERE bc2.BillNo = rb.BillNo 
                                          AND bc2.CustomerId = rb.CustomerId 
                                          AND bc2.CollectionDate > rb.IssueDate
                                     )
                                THEN (rb.TotalBillAmount * 0.05)
                                ELSE 0
                            END AS ArrearAmount
                        FROM 
                            [RmsDb].[dbo].[RMS_RENT_AND_UTILITY_BILL] rb
                        LEFT JOIN (
                            SELECT 
                                BillNo, 
                                CustomerId, 
                                SUM(DueAmount) PreviousDueAmount,
                                SUM(PaidAmount) AS TotalPaid
                            FROM 
                                [RmsDb].[dbo].[RMS_BILL_COLLECTION]
                            WHERE 
                                BillType = 2 -- BillType 2 for Rent
                            GROUP BY 
                                BillNo, CustomerId
                        ) bc 
                        ON rb.BillNo = bc.BillNo 
                        AND rb.CustomerId = bc.CustomerId
                        WHERE 
                            rb.CustomerId = @CustomerId
                            AND rb.IssueDate = (
                                SELECT MAX(IssueDate) 
                                FROM [RmsDb].[dbo].[RMS_RENT_AND_UTILITY_BILL] 
                                WHERE CustomerId = @CustomerId 
                                AND IssueDate < @BillDate
                            )
                    ),
    
                    -- CTE for Utility Bill
                    UtilityBillCTE AS (
                        SELECT 
                            ub.BillNo,
                            ub.CustomerId,
                            ub.TotalAmount,
                            bc.PreviousDueAmount AS PreviousDueAmount,
                            CASE 
                                WHEN (ub.TotalAmount - ISNULL(bc.TotalPaid, 0)) > 0 
                                     AND EXISTS (
                                        SELECT 1 
                                        FROM [RmsDb].[dbo].[RMS_BILL_COLLECTION] bc2 
                                        WHERE bc2.BillNo = ub.BillNo 
                                          AND bc2.CustomerId = ub.CustomerId 
                                          AND bc2.CollectionDate > ub.IssueDate
                                     )
                                THEN (ub.TotalAmount * 0.05)
                                ELSE 0
                            END AS ArrearAmount
                        FROM 
                            [RmsDb].[dbo].[RMS_UTILITY_BILL] ub
                        LEFT JOIN (
                            SELECT 
                                BillNo, 
                                CustomerId, 
                                SUM(DueAmount) PreviousDueAmount,
                                SUM(PaidAmount) AS TotalPaid
                            FROM 
                                [RmsDb].[dbo].[RMS_BILL_COLLECTION]
                            WHERE 
                                BillType = 3 -- BillType 3 for Utility
                            GROUP BY 
                                BillNo, CustomerId
                        ) bc 
                        ON ub.BillNo = bc.BillNo 
                        AND ub.CustomerId = bc.CustomerId
                        WHERE 
                            ub.CustomerId = @CustomerId
                            AND ub.IssueDate = (
                                SELECT MAX(IssueDate) 
                                FROM [RmsDb].[dbo].[RMS_UTILITY_BILL] 
                                WHERE CustomerId = @CustomerId 
                                AND IssueDate < @BillDate
                            )
                    )

                    -- Select the results based on the BillType input
                    SELECT 
                        @CustomerId AS CustomerId,
                        ISNULL(SUM(PreviousDueAmount), 0) AS PreviousDueAmount,
                        ISNULL(SUM(ArrearAmount), 0) AS ArrearAmount
                    FROM 
                        (
                            -- Pick the appropriate CTE based on the BillType
                            SELECT * FROM ElectricBillCTE WHERE @BillType = 1
                            UNION ALL
                            SELECT * FROM RentBillCTE WHERE @BillType = 2
                            UNION ALL
                            SELECT * FROM UtilityBillCTE WHERE @BillType = 3
                        ) AS CalculatedAmounts;

                END


                --exec SP_GET_DUE_ARREAR_AMOUNT 7,'2024-11-1',2 

            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
