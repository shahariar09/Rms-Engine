using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class update_GLOBAL_SETUP_add_IsFixServiceCharge_and_IsFixDemandCharge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFixDemandCharge",
                table: "RMS_GLOBAL_SETUP",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFixServiceCharge",
                table: "RMS_GLOBAL_SETUP",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFixDemandCharge",
                table: "RMS_GLOBAL_SETUP");

            migrationBuilder.DropColumn(
                name: "IsFixServiceCharge",
                table: "RMS_GLOBAL_SETUP");
        }
    }
}
