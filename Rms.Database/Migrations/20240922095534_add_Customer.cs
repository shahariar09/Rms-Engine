using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class add_Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RMS_CUSTOMER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplexId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerType = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelNo = table.Column<int>(type: "int", nullable: true),
                    FixEletricBillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EletricBillType = table.Column<int>(type: "int", nullable: true),
                    EletricMetterNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EletricMetterLastReading = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EletricMetterLastReadingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false),
                    OpeningReading = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterBill = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtherBill = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GassBillType = table.Column<int>(type: "int", nullable: true),
                    GassBillUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasStoveType = table.Column<int>(type: "int", nullable: true),
                    GasSingStoveAmout = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasDoubStoveAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RentActiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdvanceRentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasOpeningReading = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasMeterLastReading = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GassMeterLastReadingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIDImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDocumentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsElectricBillRequird = table.Column<bool>(type: "bit", nullable: false),
                    IsGasBillRequire = table.Column<bool>(type: "bit", nullable: false),
                    IsWaterBillRequire = table.Column<bool>(type: "bit", nullable: false),
                    AreaSFT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RateSrf = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DueAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MotorcycleQuantity = table.Column<int>(type: "int", nullable: true),
                    CarQuantity = table.Column<int>(type: "int", nullable: true),
                    IsRentFix = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RMS_CUSTOMER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RMS_CUSTOMER_RMS_COMPLEX_ComplexId",
                        column: x => x.ComplexId,
                        principalTable: "RMS_COMPLEX",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RMS_COMPLEX_UserId",
                table: "RMS_COMPLEX",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RMS_CUSTOMER_ComplexId",
                table: "RMS_CUSTOMER",
                column: "ComplexId");

            migrationBuilder.AddForeignKey(
                name: "FK_RMS_COMPLEX_AspNetUsers_UserId",
                table: "RMS_COMPLEX",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RMS_COMPLEX_AspNetUsers_UserId",
                table: "RMS_COMPLEX");

            migrationBuilder.DropTable(
                name: "RMS_CUSTOMER");

            migrationBuilder.DropIndex(
                name: "IX_RMS_COMPLEX_UserId",
                table: "RMS_COMPLEX");
        }
    }
}
