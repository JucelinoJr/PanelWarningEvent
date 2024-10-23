using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PepPanel.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatePP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PP_EVENT",
                columns: table => new
                {
                    EV_ID = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EV_EVENTDATETIME = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EV_DESCRIPTION = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EV_RESPONSIBLE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EV_CREATEDATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EV_UPDATEDATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PP_EVENT", x => x.EV_ID);
                });

            migrationBuilder.CreateTable(
                name: "PP_WARNING",
                columns: table => new
                {
                    WR_ID = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    WR_DESCRIPTION = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    WR_CREATEDATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    WR_UPDATEDATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PP_WARNING", x => x.WR_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PP_EVENT");

            migrationBuilder.DropTable(
                name: "PP_WARNING");
        }
    }
}
