using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class update_customer_revise_property_spelling_mistakes_electric_metter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EletricMetterNo",
                table: "RMS_CUSTOMER",
                newName: "ElectricMetterNo");

            migrationBuilder.RenameColumn(
                name: "EletricMetterLastReadingDate",
                table: "RMS_CUSTOMER",
                newName: "ElectricMetterLastReadingDate");

            migrationBuilder.RenameColumn(
                name: "EletricMetterLastReading",
                table: "RMS_CUSTOMER",
                newName: "ElectricMetterLastReading");

            migrationBuilder.RenameColumn(
                name: "EletricBillType",
                table: "RMS_CUSTOMER",
                newName: "ElectricBillType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ElectricMetterNo",
                table: "RMS_CUSTOMER",
                newName: "EletricMetterNo");

            migrationBuilder.RenameColumn(
                name: "ElectricMetterLastReadingDate",
                table: "RMS_CUSTOMER",
                newName: "EletricMetterLastReadingDate");

            migrationBuilder.RenameColumn(
                name: "ElectricMetterLastReading",
                table: "RMS_CUSTOMER",
                newName: "EletricMetterLastReading");

            migrationBuilder.RenameColumn(
                name: "ElectricBillType",
                table: "RMS_CUSTOMER",
                newName: "EletricBillType");
        }
    }
}
