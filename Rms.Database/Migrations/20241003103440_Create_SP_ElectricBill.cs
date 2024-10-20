using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class Create_SP_ElectricBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            Create or ALTER PROCEDURE [dbo].[SP_ElectricBill]
	
			@CustomerId NVARCHAR(50),
			  @Year INT,
				@Month INT
			AS
			BEGIN

			 DECLARE @StartDate DATE = DATEFROMPARTS(@Year, @Month, 1);
			 DECLARE @EndDate DATE = EOMONTH(@StartDate);

			SELECT 
                eb.BillNo AS BillNo,
                eb.IssueDate,
                CAST(cmplx.Name AS VARCHAR) + ' ' + CAST(c.LevelNo AS VARCHAR) AS AccountNo,
                eb.DueDate LastPayDate,
                c.Name AS CustomerName,
                c.ContactName AS Shop,
                c.EletricMetterNo AS MetterNo,  -- Corrected spelling of 'MetterNo'
                eb.PresentReading AS PresentReading,
	            FORMAT(DATEADD(MONTH, -1, eb.IssueDate), 'MMM-yy') AS ForMonthOf,
                eb.CreatedOn AS PresentReadingDate,
                ROUND(1.00, 2) AS PreviousReading,
                ROUND(eb.PresentReading - 1, 2) AS Consumption,

                ROUND(CASE c.CustomerType
                    WHEN 1 THEN gs.ResidentialEBill
                    WHEN 2 THEN gs.CommercialEBill
                END, 2) AS UnitPrice,

                ROUND((eb.PresentReading - 1) * 
                (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill WHEN c.CustomerType = 2 THEN gs.CommercialEBill END), 2) AS ConsumptionPrice,

                -- Calculate ServiceCharge based on IsFixServiceCharge
                ROUND(CASE 
                    WHEN gs.IsFixServiceCharge = 1 THEN gs.ServiceCharge  -- Fixed service charge
                    ELSE ((gs.ServiceCharge * (eb.PresentReading - 1) * 
                          (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill WHEN c.CustomerType = 2 THEN gs.CommercialEBill END)) / 100)  -- Percentage of ConsumptionPrice
                END, 2) AS ServiceCharge,

                -- Calculate DemandCharge based on IsFixDemandCharge
                ROUND(CASE 
                    WHEN gs.IsFixDemandCharge = 1 THEN gs.DemandCharge  -- Fixed demand charge
                    ELSE ((gs.DemandCharge * (eb.PresentReading - 1) * 
                          (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill WHEN c.CustomerType = 2 THEN gs.CommercialEBill END)) / 100)  -- Percentage of ConsumptionPrice
                END, 2) AS DemandCharge,

                -- Total calculation including dynamic ServiceCharge and DemandCharge
                ROUND(
                    (eb.PresentReading - 1) * 
                    (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill WHEN c.CustomerType = 2 THEN gs.CommercialEBill END) +
                    CASE 
                        WHEN gs.IsFixServiceCharge = 1 THEN gs.ServiceCharge  -- Fixed service charge
                        ELSE ((gs.ServiceCharge * (eb.PresentReading - 1) * 
                            (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill WHEN c.CustomerType = 2 THEN gs.CommercialEBill END)) / 100)  -- Percentage of ConsumptionPrice
                    END +
                    CASE 
                        WHEN gs.IsFixDemandCharge = 1 THEN gs.DemandCharge  -- Fixed demand charge
                        ELSE ((gs.DemandCharge * (eb.PresentReading - 1) * 
                            (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill WHEN c.CustomerType = 2 THEN gs.CommercialEBill END)) / 100)  -- Percentage of ConsumptionPrice
                    END, 2) AS Total,

                gs.VAT AS VatPercentage,

                -- Calculate VatAmount
                ROUND((gs.VAT * (
                        (eb.PresentReading - 1) * 
                        (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill WHEN c.CustomerType = 2 THEN gs.CommercialEBill END) + 
                        CASE 
                            WHEN gs.IsFixServiceCharge = 1 THEN gs.ServiceCharge
                            ELSE ((gs.ServiceCharge * (eb.PresentReading - 1) * 
                                (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill WHEN c.CustomerType = 2 THEN gs.CommercialEBill END)) / 100)
                        END + 
                        CASE 
                            WHEN gs.IsFixDemandCharge = 1 THEN gs.DemandCharge
                            ELSE ((gs.DemandCharge * (eb.PresentReading - 1) * 
                                (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill WHEN c.CustomerType = 2 THEN gs.CommercialEBill END)) / 100)
                        END)) / 100, 2) AS VatAmount,

                -- Calculate GrandTotal
                ROUND(
                    ((eb.PresentReading - 1) * 
                    (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill WHEN c.CustomerType = 2 THEN gs.CommercialEBill END) +
                    CASE 
                        WHEN gs.IsFixServiceCharge = 1 THEN gs.ServiceCharge
                        ELSE ((gs.ServiceCharge * (eb.PresentReading - 1) * 
                            (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill WHEN c.CustomerType = 2 THEN gs.CommercialEBill END)) / 100)
                    END + 
                    CASE 
                        WHEN gs.IsFixDemandCharge = 1 THEN gs.DemandCharge
                        ELSE ((gs.DemandCharge * (eb.PresentReading - 1) * 
                            (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill WHEN c.CustomerType = 2 THEN gs.CommercialEBill END)) / 100)
                    END + 
                    ROUND(
                        (gs.VAT * (
                            (eb.PresentReading - 1) * 
                            (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill WHEN c.CustomerType = 2 THEN gs.CommercialEBill END) +
                            CASE 
                                WHEN gs.IsFixServiceCharge = 1 THEN gs.ServiceCharge
                                ELSE ((gs.ServiceCharge * (eb.PresentReading - 1) * 
                                    (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill WHEN c.CustomerType = 2 THEN gs.CommercialEBill END)) / 100)
                            END + 
                            CASE 
                                WHEN gs.IsFixDemandCharge = 1 THEN gs.DemandCharge
                                ELSE ((gs.DemandCharge * (eb.PresentReading - 1) * 
                                    (CASE WHEN c.CustomerType = 1 THEN gs.ResidentialEBill WHEN c.CustomerType = 2 THEN gs.CommercialEBill END)) / 100)
                            END)) / 100, 2)
                    ), 2) AS GrandTotal

            FROM 
                RMS_ELECTRIC_BILL eb
            LEFT JOIN 
                RMS_CUSTOMER c ON eb.CustomerId = c.Id
            LEFT JOIN 
                RMS_COMPLEX cmplx ON c.ComplexId = cmplx.Id  -- Corrected spelling of 'ComplexId'
            CROSS JOIN 
                RMS_GLOBAL_SETUP gs
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
