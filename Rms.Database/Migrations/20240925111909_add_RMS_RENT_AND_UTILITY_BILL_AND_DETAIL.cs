using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class add_RMS_RENT_AND_UTILITY_BILL_AND_DETAIL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RMS_RENT_AND_UTILITY_BILL",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BillNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalBillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BillCollectStatus = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RMS_RENT_AND_UTILITY_BILL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RMS_RENT_AND_UTILITY_BILL_RMS_CUSTOMER_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "RMS_CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RMS_RENT_AND_UTILITY_BILL_DETAIL",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentAndUtilityBillId = table.Column<long>(type: "bigint", nullable: false),
                    MonthName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    RentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterBill = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtherBill = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasBillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_RMS_RENT_AND_UTILITY_BILL_DETAIL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RMS_RENT_AND_UTILITY_BILL_DETAIL_RMS_RENT_AND_UTILITY_BILL_RentAndUtilityBillId",
                        column: x => x.RentAndUtilityBillId,
                        principalTable: "RMS_RENT_AND_UTILITY_BILL",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RMS_RENT_AND_UTILITY_BILL_CustomerId",
                table: "RMS_RENT_AND_UTILITY_BILL",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RMS_RENT_AND_UTILITY_BILL_DETAIL_RentAndUtilityBillId",
                table: "RMS_RENT_AND_UTILITY_BILL_DETAIL",
                column: "RentAndUtilityBillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RMS_RENT_AND_UTILITY_BILL_DETAIL");

            migrationBuilder.DropTable(
                name: "RMS_RENT_AND_UTILITY_BILL");
        }
    }
}
