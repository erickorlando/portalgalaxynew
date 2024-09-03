using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalGalaxy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EstirarCamposTaller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TemarioUrl",
                table: "Taller",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PortadaUrl",
                table: "Taller",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TemarioUrl",
                table: "Taller",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PortadaUrl",
                table: "Taller",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
