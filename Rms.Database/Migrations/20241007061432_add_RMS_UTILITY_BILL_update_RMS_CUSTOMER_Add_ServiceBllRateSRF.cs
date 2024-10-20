using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class add_RMS_UTILITY_BILL_update_RMS_CUSTOMER_Add_ServiceBllRateSRF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ServiceBillRateSrf",
                table: "RMS_CUSTOMER",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RMS_UTILITY_BILL",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BillNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceBillAreaSFT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceBillRateSrf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceBillTotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TowerBillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GeneratorBillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ParkingBillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillPayStatus = table.Column<bool>(type: "bit", nullable: false),
                    BillPayDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RMS_UTILITY_BILL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RMS_UTILITY_BILL_RMS_CUSTOMER_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "RMS_CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RMS_UTILITY_BILL_CustomerId",
                table: "RMS_UTILITY_BILL",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RMS_UTILITY_BILL");

            migrationBuilder.DropColumn(
                name: "ServiceBillRateSrf",
                table: "RMS_CUSTOMER");
        }
    }
}
