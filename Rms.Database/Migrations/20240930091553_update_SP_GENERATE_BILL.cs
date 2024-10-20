using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class update_SP_GENERATE_BILL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE Or ALTER PROCEDURE [dbo].[SP_GENERATE_BILL]
	
			@CustomerId NVARCHAR(50)
			AS
			BEGIN

			Create table #temp
			 (
				MonthsName NVARCHAR(50),
				YearName nvarchar(50),
				RentAmount DECIMAL,
				ServiceCharge DECIMAL,
				WaterBill NVARCHAR(50),
				OtherBill DECIMAL,
				GassBill NVARCHAR(50)
				
			 )
		DECLARE @date datetime

		SELECT @date = (SELECT RentActiveDate FROM RMS_CUSTOMER WHERE Id = @CustomerId)

		DECLARE @Year1 INT
		DECLARE @Month1 INT

		DECLARE @Month2 INT
		DECLARE @Year2 int

		SET @Year1 = DATEPART(YEAR,CONVERT(DATE, @date ,101))
		SET @Month1 = DATEPART(MONTH,CONVERT(DATE,@date,101))
		SET @Year2 = DATEPART(YEAR,CONVERT(DATE,GETDATE(),101))
		SET @Month2 = DATEPART(MONTH,CONVERT(DATE,GETDATE(),101))


		 WHILE (@Year1 <= @Year2)
			BEGIN
		DECLARE @monthName NVARCHAR(50)
		DECLARE @yearName NVARCHAR(50)
		DECLARE @formate NVARCHAR(50)

		SET @formate = (CONVERT(NVARCHAR(50) ,@Year1) + '/' + CONVERT(NVARCHAR(50),@Month1) + '/' + CONVERT(NVARCHAR(50),1))
		SET @yearName =  CONVERT(nvarchar(50),@Year1)
		SET @monthName =   DateName(mm,@formate)
		 BEGIN

		 IF NOT EXISTS(
		 SELECT * FROM RMS_RENT_AND_UTILITY_BILL raub
		 LEFT JOIN RMS_RENT_AND_UTILITY_BILL_DETAIL raubd on raub.Id=raubd.RentAndUtilityBillId
		 WHERE raub.CustomerId = @CustomerId 
		 AND raubd.Month = MONTH(@formate) AND raubd.Year =YEAR(@formate))

		BEGIN
		INSERT INTO #temp
		        ( MonthsName, YearName, RentAmount, ServiceCharge,WaterBill,OtherBill,GassBill)

		SELECT @monthName, @yearName, cu.RentAmount,cu.ServiceCharge,
		--cu.WaterBill,
		CASE WHEN (ISNULL(IsWaterBillRequired,0)=1) THEN '0'
        ELSE
		ISNULL((SELECT CAST(wbg.BillMonthTotal AS NVARCHAR(50))  FROM RMS_GASS_BILL wbg WHERE wbg.CustomerId =  @CustomerId AND MONTH(IssueDate) = MONTH(@formate) AND YEAR(IssueDate) =YEAR(@formate)),0) END ,
		cu.OtherBill,
		CASE WHEN (ISNULL(cu.IsGasBillRequired,0)=1) THEN '0'
		ELSE
	    ISNULL((SELECT CAST(gbg.BillMonthTotal AS NVARCHAR(50))   FROM RMS_GASS_BILL gbg WHERE gbg.CustomerId =  @CustomerId AND MONTH(IssueDate) = MONTH(@formate) AND YEAR(IssueDate) =YEAR(@formate)),0) END
        FROM  RMS_CUSTOMER cu WHERE cu.Id = @CustomerId
		END
		END
		IF(@Month1 = 12)
		BEGIN
		SET @Month1 = 1;
		SET @Year1 = @Year1+1;
		END
		ELSE IF(@Month1 < 12)
		BEGIN
		SET @Month1 = @Month1 + 1;
		END
			END

		SELECT *
		 
		 FROM #temp
		
		DROP TABLE #temp
		end
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
