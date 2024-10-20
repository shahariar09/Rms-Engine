using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class update_CUSTOMER_add_Deed_date_and_Security_Deposite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeedEndDate",
                table: "RMS_CUSTOMER",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeedStartDate",
                table: "RMS_CUSTOMER",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SecurityDeposit",
                table: "RMS_CUSTOMER",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeedEndDate",
                table: "RMS_CUSTOMER");

            migrationBuilder.DropColumn(
                name: "DeedStartDate",
                table: "RMS_CUSTOMER");

            migrationBuilder.DropColumn(
                name: "SecurityDeposit",
                table: "RMS_CUSTOMER");
        }
    }
}
