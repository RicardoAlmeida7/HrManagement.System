using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class set_temp_password_hash_field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempPasswordHash",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempPasswordHash",
                table: "AspNetUsers");
        }
    }
}
