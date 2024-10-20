using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class update_CUSTOMER_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsWaterBillRequire",
                table: "RMS_CUSTOMER",
                newName: "isFixElectricBill");

            migrationBuilder.RenameColumn(
                name: "IsRentFix",
                table: "RMS_CUSTOMER",
                newName: "IsWaterBillRequired");

            migrationBuilder.RenameColumn(
                name: "IsGasBillRequire",
                table: "RMS_CUSTOMER",
                newName: "IsRentFixed");

            migrationBuilder.RenameColumn(
                name: "IsElectricBillRequird",
                table: "RMS_CUSTOMER",
                newName: "IsGasBillRequired");

            migrationBuilder.RenameColumn(
                name: "GasSingStoveAmout",
                table: "RMS_CUSTOMER",
                newName: "GasSingleStoveAmount");

            migrationBuilder.RenameColumn(
                name: "GasDoubStoveAmount",
                table: "RMS_CUSTOMER",
                newName: "GasDoubleStoveAmount");

            migrationBuilder.RenameColumn(
                name: "FixEletricBillAmount",
                table: "RMS_CUSTOMER",
                newName: "FixElectricBillAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isFixElectricBill",
                table: "RMS_CUSTOMER",
                newName: "IsWaterBillRequire");

            migrationBuilder.RenameColumn(
                name: "IsWaterBillRequired",
                table: "RMS_CUSTOMER",
                newName: "IsRentFix");

            migrationBuilder.RenameColumn(
                name: "IsRentFixed",
                table: "RMS_CUSTOMER",
                newName: "IsGasBillRequire");

            migrationBuilder.RenameColumn(
                name: "IsGasBillRequired",
                table: "RMS_CUSTOMER",
                newName: "IsElectricBillRequird");

            migrationBuilder.RenameColumn(
                name: "GasSingleStoveAmount",
                table: "RMS_CUSTOMER",
                newName: "GasSingStoveAmout");

            migrationBuilder.RenameColumn(
                name: "GasDoubleStoveAmount",
                table: "RMS_CUSTOMER",
                newName: "GasDoubStoveAmount");

            migrationBuilder.RenameColumn(
                name: "FixElectricBillAmount",
                table: "RMS_CUSTOMER",
                newName: "FixEletricBillAmount");
        }
    }
}
