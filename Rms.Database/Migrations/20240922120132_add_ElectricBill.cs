using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class add_ElectricBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RMS_ELECTRIC_BILL",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BillNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EletricBillType = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PresentReading = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConsumedUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ElectricCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DemandCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrincipalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DutyOnKhw = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShopServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Vat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BillMonthTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BillPayStatus = table.Column<bool>(type: "bit", nullable: false),
                    BillPayDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<long>(type: "bigint", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RMS_ELECTRIC_BILL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RMS_ELECTRIC_BILL_RMS_CUSTOMER_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "RMS_CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RMS_ELECTRIC_BILL_CustomerId",
                table: "RMS_ELECTRIC_BILL",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RMS_ELECTRIC_BILL");
        }
    }
}
