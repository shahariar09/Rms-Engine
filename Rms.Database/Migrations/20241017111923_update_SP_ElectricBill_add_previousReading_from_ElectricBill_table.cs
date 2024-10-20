using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class update_SP_ElectricBill_add_previousReading_from_ElectricBill_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            Create or Alter PROCEDURE [dbo].[SP_ElectricBill]
	
			@CustomerId NVARCHAR(50),
			  @Year INT,
				@Month INT
			AS
			BEGIN

			 DECLARE @StartDate DATE = DATEFROMPARTS(@Year, @Month, 1);
            DECLARE @EndDate DATE = EOMONTH(@StartDate);

            WITH PreviousReadingCTE AS (
                SELECT 
                    eb.CustomerId, 
                    MAX(eb.BillNo) AS MaxBillNo, 
                    MAX(eb2.BillNo) AS PreviousBillNo,
                    COALESCE(
                        (SELECT TOP 1 eb1.IssueDate 
                         FROM RMS_ELECTRIC_BILL eb1 
                         WHERE eb1.CustomerId = eb.CustomerId 
                         AND eb1.BillNo <> MAX(eb2.BillNo) 
                         ORDER BY eb1.BillNo DESC
                        ), c.CreatedOn
                    ) AS PreviousReadingDate,
                    eb.PreviousReading AS PreviousReading
                FROM 
                    RMS_ELECTRIC_BILL eb
                JOIN 
                    RMS_CUSTOMER c ON eb.CustomerId = c.Id
                LEFT JOIN 
                    RMS_ELECTRIC_BILL eb2 ON eb2.CustomerId = eb.CustomerId
                WHERE 
                    eb.CustomerId = @CustomerId
                GROUP BY 
                    eb.CustomerId, c.CreatedOn, eb.PreviousReading
            )

            SELECT 
                eb.BillNo AS BillNo,
                eb.IssueDate,
                CAST(cmplx.Name AS VARCHAR) + ' ' + CAST(c.LevelNo AS VARCHAR) AS AccountNo,
                dbo.GetLastWorkingDay(2024, 9) AS LastPayDate,
                c.Name AS CustomerName,
                c.ContactName AS Shop,
                c.ElectricMetterNo AS ElectricMetterNo,
                eb.PresentReading AS PresentReading,
                FORMAT(DATEADD(MONTH, -1, eb.IssueDate), 'MMM-yy') AS ForMonthOf,
                eb.CreatedOn AS PresentReadingDate,

                PreviousReadingCTE.PreviousReadingDate,
                ROUND(PreviousReadingCTE.PreviousReading, 2) AS PreviousReading,

                ROUND(eb.PresentReading - ROUND(PreviousReadingCTE.PreviousReading, 2), 2) AS Consumption,

                ROUND(CASE c.CustomerType
                    WHEN 1 THEN gs.ResidentialEBill
                    WHEN 2 THEN gs.CommercialEBill
                END, 2) AS UnitPrice,

                ROUND((eb.PresentReading - ROUND(PreviousReadingCTE.PreviousReading, 2)) * 
                      (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill 
                            WHEN c.CustomerType = 2 THEN gs.CommercialEBill 
                       END), 2) AS ConsumptionPrice,

                ROUND(CASE 
                    WHEN gs.IsFixServiceCharge = 1 THEN gs.ServiceCharge  
                    ELSE ((gs.ServiceCharge * (eb.PresentReading - ROUND(PreviousReadingCTE.PreviousReading, 2)) * 
                          (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill 
                                WHEN c.CustomerType = 2 THEN gs.CommercialEBill 
                           END)) / 100) 
                END, 2) AS ServiceCharge,

                ROUND(CASE 
                    WHEN gs.IsFixDemandCharge = 1 THEN gs.DemandCharge  
                    ELSE ((gs.DemandCharge * (eb.PresentReading - ROUND(PreviousReadingCTE.PreviousReading, 2)) * 
                          (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill 
                                WHEN c.CustomerType = 2 THEN gs.CommercialEBill 
                           END)) / 100)  
                END, 2) AS DemandCharge,

                ROUND(
                    (eb.PresentReading - ROUND(PreviousReadingCTE.PreviousReading, 2)) * 
                    (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill 
                          WHEN c.CustomerType = 2 THEN gs.CommercialEBill 
                    END) +
                    CASE 
                        WHEN gs.IsFixServiceCharge = 1 THEN gs.ServiceCharge  
                        ELSE ((gs.ServiceCharge * (eb.PresentReading - ROUND(PreviousReadingCTE.PreviousReading, 2)) * 
                              (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill 
                                    WHEN c.CustomerType = 2 THEN gs.CommercialEBill 
                               END)) / 100)  
                    END +
                    CASE 
                        WHEN gs.IsFixDemandCharge = 1 THEN gs.DemandCharge  
                        ELSE ((gs.DemandCharge * (eb.PresentReading - ROUND(PreviousReadingCTE.PreviousReading, 2)) * 
                              (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill 
                                    WHEN c.CustomerType = 2 THEN gs.CommercialEBill 
                               END)) / 100)  
                    END, 2) AS Total,

                gs.VAT AS VatPercentage,

               ROUND(
                (gs.VAT * 
                 ((eb.PresentReading - ROUND(PreviousReadingCTE.PreviousReading, 2)) * 
                  (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill 
                        WHEN c.CustomerType = 2 THEN gs.CommercialEBill 
                   END)) / 100), 2) AS VatAmount,


              ROUND(
                (
                    (eb.PresentReading - ROUND(PreviousReadingCTE.PreviousReading, 2)) * 
                    (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill 
                          WHEN c.CustomerType = 2 THEN gs.CommercialEBill 
                    END) + 
                    gs.ServiceCharge + 
                    gs.DemandCharge + 
                    (
                        (gs.VAT / 100) * 
                        ((eb.PresentReading - ROUND(PreviousReadingCTE.PreviousReading, 2)) * 
                         (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill 
                               WHEN c.CustomerType = 2 THEN gs.CommercialEBill 
                         END))
                    )
                ), 2
            ) AS GrandTotal,

            COALESCE(
                    (SELECT SUM(bc.DueAmount)
                     FROM RMS_BILL_COLLECTION bc
                     WHERE bc.BillNo = (SELECT TOP 1 eb.BillNo 
                                        FROM RMS_ELECTRIC_BILL eb 
                                        WHERE eb.CustomerId = c.Id 
                                          AND eb.BillNo <> (SELECT MAX(eb2.BillNo) 
                                                            FROM RMS_ELECTRIC_BILL eb2 
                                                            WHERE eb2.CustomerId = c.Id)
                                        ORDER BY eb.billNo DESC)
                       AND bc.BillType = 1
                       AND bc.CustomerId = c.Id
                    ), 0
                ) AS PreviousDueAmount,
		            5 ArrearPercentage,
	            ROUND(
                COALESCE(
                    (SELECT 
                        CASE 
                          WHEN (SELECT TOP 1 bc.CollectionDate 
                                FROM RMS_BILL_COLLECTION bc 
                                WHERE bc.BillNo = eb.BillNo 
                                  AND bc.CustomerId = c.Id 
                                  AND bc.BillType = 1
                                ORDER BY bc.CollectionDate ASC) > eb.DueDate 
                          THEN eb.BillMonthTotal * 0.05 
                          ELSE 0 
                        END
                     FROM RMS_ELECTRIC_BILL eb
                     WHERE eb.CustomerId = c.Id 
                       AND eb.BillNo <> (SELECT MAX(eb2.BillNo) 
                                         FROM RMS_ELECTRIC_BILL eb2 
                                         WHERE eb2.CustomerId = c.Id)
                    ), 0
                ), 2) AS ArrearAmount

            FROM 
                RMS_ELECTRIC_BILL eb
            LEFT JOIN 
                RMS_CUSTOMER c ON eb.CustomerId = c.Id
            LEFT JOIN 
                RMS_COMPLEX cmplx ON c.ComplexId = cmplx.Id
            CROSS JOIN 
                RMS_GLOBAL_SETUP gs
            LEFT JOIN 
                PreviousReadingCTE ON eb.CustomerId = PreviousReadingCTE.CustomerId
            WHERE 
                eb.CustomerId = @CustomerId
                AND eb.IssueDate >= @StartDate
                AND eb.IssueDate <= @EndDate;
            end
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
