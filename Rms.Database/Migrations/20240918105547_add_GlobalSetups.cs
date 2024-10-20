using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class add_GlobalSetups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RMS_GLOBAL_SETUP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentialEBill = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommercialEBill = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ResidentialMiniUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommercialMiniUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DutyOnKHW = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DemandCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ElectricMotorCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DelayCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_RMS_GLOBAL_SETUP", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RMS_GLOBAL_SETUP");
        }
    }
}
