using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class update_RMS_RENT_AND_UTILITY_BILL_add_TotalAmount_update_RMS_UTILITY_BILL_add_TotalBillAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalBillAmount",
                table: "RMS_UTILITY_BILL",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "RMS_RENT_AND_UTILITY_BILL",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalBillAmount",
                table: "RMS_UTILITY_BILL");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "RMS_RENT_AND_UTILITY_BILL");
        }
    }
}
