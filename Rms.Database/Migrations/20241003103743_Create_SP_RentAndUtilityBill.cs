using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class Create_SP_RentAndUtilityBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            Create Or ALTER PROCEDURE [dbo].[SP_RentAndUtilityBill]
	
			@CustomerId NVARCHAR(50),
			  @Year INT,
				@Month INT
			AS
			BEGIN

			 DECLARE @StartDate DATE = DATEFROMPARTS(@Year, @Month, 1);
			 DECLARE @EndDate DATE = EOMONTH(@StartDate);

			SELECT 
				rub.BillNo AS BillNo,
				rub.IssueDate,
				rub.DueDate LastPayDate,
				CAST(cmplx.Name AS VARCHAR) + ' ' + CAST(c.LevelNo AS VARCHAR) AS AccountNo,
				c.Name AS CustomerName,
				c.ContactName AS Shop,
				c.AreaSFT AreaSFT,
				(SELECT TOP 1 Name FROM CpanelSeeds) FirstParty,
				c.Name SecondParty,
				c.DeedStartDate,
				c.DeedEndDate,
				c.SecurityDeposit,
				FORMAT(DATEADD(MONTH, -1, rub.IssueDate), 'MMM-yy') AS ForMonthOf,
				c.RentAmount MonthlyRent,
				(
					SELECT 
					SUM(bc.DueAmount) AS TotalDueAmount
					FROM 
						RMS_RENT_AND_UTILITY_BILL rub
					LEFT JOIN 
						RMS_BILL_COLLECTION bc ON rub.BillNo = bc.BillNo
					WHERE 
					rub.CustomerId = @CustomerId
					AND YEAR(rub.IssueDate) = @Year
					AND MONTH(rub.IssueDate) < @Month
				) PreviousDueAmount,
				(
				c.RentAmount +
				(
					SELECT 
					SUM(bc.DueAmount) AS TotalDueAmount
					FROM 
						RMS_RENT_AND_UTILITY_BILL rub
					LEFT JOIN 
						RMS_BILL_COLLECTION bc ON rub.BillNo = bc.BillNo
					WHERE 
					rub.CustomerId = @CustomerId
					AND bc.BillType=2
					AND YEAR(rub.IssueDate) = @Year
					AND MONTH(rub.IssueDate) < @Month
				)) Total
		
	
    

			FROM 
				RMS_RENT_AND_UTILITY_BILL rub
			LEFT JOIN 
				RMS_BILL_COLLECTION bc ON rub.BillNo = bc.BillNo
			LEFT JOIN 
				RMS_CUSTOMER c ON rub.CustomerId = c.Id
			LEFT JOIN 
				RMS_COMPLEX cmplx ON c.ComplexId = cmplx.Id  -- Corrected spelling of 'ComplexId'
		
			WHERE 
				rub.CustomerId = @CustomerId
				 AND rub.IssueDate >= @StartDate
				  AND rub.IssueDate <= @EndDate
			group by rub.BillNo,
			rub.IssueDate,
			rub.DueDate,
			cmplx.Name,
			c.LevelNo,
			c.Name,
			c.ContactName,
			c.AreaSFT,
			c.DeedStartDate,
			c.DeedEndDate,
			c.SecurityDeposit,
			c.RentAmount


			
					end
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
