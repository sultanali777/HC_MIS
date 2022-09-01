using Microsoft.EntityFrameworkCore.Migrations;

namespace HC_MIS.Migrations
{
    public partial class chngParam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file_path",
                table: "hc_dgoffice");

            migrationBuilder.RenameColumn(
                name: "cheque_statusId",
                table: "hc_hfAcknowledge",
                newName: "statusId");

            migrationBuilder.AddColumn<string>(
                name: "file_path",
                table: "hc_development",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "release_amount",
                table: "hc_development",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file_path",
                table: "hc_development");

            migrationBuilder.DropColumn(
                name: "release_amount",
                table: "hc_development");

            migrationBuilder.RenameColumn(
                name: "statusId",
                table: "hc_hfAcknowledge",
                newName: "cheque_statusId");

            migrationBuilder.AddColumn<string>(
                name: "file_path",
                table: "hc_dgoffice",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
