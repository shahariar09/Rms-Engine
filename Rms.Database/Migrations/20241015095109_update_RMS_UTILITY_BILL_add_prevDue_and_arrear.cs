using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class update_RMS_UTILITY_BILL_add_prevDue_and_arrear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ArrearAmount",
                table: "RMS_UTILITY_BILL",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PreviousDueAmount",
                table: "RMS_UTILITY_BILL",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrearAmount",
                table: "RMS_UTILITY_BILL");

            migrationBuilder.DropColumn(
                name: "PreviousDueAmount",
                table: "RMS_UTILITY_BILL");
        }
    }
}
