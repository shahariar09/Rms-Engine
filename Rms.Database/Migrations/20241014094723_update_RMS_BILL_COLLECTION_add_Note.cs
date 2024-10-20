using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Database.Migrations
{
    /// <inheritdoc />
    public partial class update_RMS_BILL_COLLECTION_add_Note : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "RMS_BILL_COLLECTION",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "RMS_BILL_COLLECTION");
        }
    }
}
