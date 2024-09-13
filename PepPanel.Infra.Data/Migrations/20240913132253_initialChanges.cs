using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PepPanel.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "WR_UPDATEDATE",
                table: "PP_WARNING",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EV_UPDATEDATE",
                table: "PP_EVENT",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "WR_UPDATEDATE",
                table: "PP_WARNING",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EV_UPDATEDATE",
                table: "PP_EVENT",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);
        }
    }
}
