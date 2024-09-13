using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PepPanel.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PP_EVENT",
                columns: table => new
                {
                    EV_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EV_EVENTDATETIME = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EV_DESCRIPTION = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EV_RESPONSIBLE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EV_CREATEDATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EV_UPDATEDATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PP_EVENT", x => x.EV_ID);
                });

            migrationBuilder.CreateTable(
                name: "PP_WARNING",
                columns: table => new
                {
                    WR_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    WR_DESCRIPTION = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    WR_CREATEDATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    WR_UPDATEDATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PP_WARNING", x => x.WR_ID);
                });
            migrationBuilder.Sql(@"
                CREATE SEQUENCE SEQ_EVENT
                START WITH 1
                INCREMENT BY 1
                MINVALUE 1
                NOCACHE
                NOCYCLE;
            ");
                        migrationBuilder.Sql(@"
                CREATE SEQUENCE SEQ_WARNING
                START WITH 1
                INCREMENT BY 1
                MINVALUE 1
                NOCACHE
                NOCYCLE;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PP_EVENT");

            migrationBuilder.DropTable(
                name: "PP_WARNING");
            migrationBuilder.Sql("DROP SEQUENCE SEQ_EVENT;");
            migrationBuilder.Sql("DROP SEQUENCE SEQ_WARNING;");
        }
    }
}
