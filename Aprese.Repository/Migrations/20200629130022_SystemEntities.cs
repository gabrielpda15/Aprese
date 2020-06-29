using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aprese.Repository.Migrations
{
    public partial class SystemEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "SEC_Identity",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "SEC_Identity",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "SEC_Identity",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CFG_Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EditionUser = table.Column<string>(maxLength: 50, nullable: true),
                    CreationUser = table.Column<string>(maxLength: 50, nullable: true),
                    EditionIp = table.Column<string>(maxLength: 50, nullable: true),
                    CreationIp = table.Column<string>(maxLength: 50, nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFG_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LOC_State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EditionUser = table.Column<string>(maxLength: 50, nullable: true),
                    CreationUser = table.Column<string>(maxLength: 50, nullable: true),
                    EditionIp = table.Column<string>(maxLength: 50, nullable: true),
                    CreationIp = table.Column<string>(maxLength: 50, nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    FederalUnity = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOC_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LOC_City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EditionUser = table.Column<string>(maxLength: 50, nullable: true),
                    CreationUser = table.Column<string>(maxLength: 50, nullable: true),
                    EditionIp = table.Column<string>(maxLength: 50, nullable: true),
                    CreationIp = table.Column<string>(maxLength: 50, nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOC_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LOC_City_LOC_State_StateId",
                        column: x => x.StateId,
                        principalTable: "LOC_State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SIS_Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EditionUser = table.Column<string>(maxLength: 50, nullable: true),
                    CreationUser = table.Column<string>(maxLength: 50, nullable: true),
                    EditionIp = table.Column<string>(maxLength: 50, nullable: true),
                    CreationIp = table.Column<string>(maxLength: 50, nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIS_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SIS_Client_LOC_City_CityId",
                        column: x => x.CityId,
                        principalTable: "LOC_City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SIS_Task",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EditionUser = table.Column<string>(maxLength: 50, nullable: true),
                    CreationUser = table.Column<string>(maxLength: 50, nullable: true),
                    EditionIp = table.Column<string>(maxLength: 50, nullable: true),
                    CreationIp = table.Column<string>(maxLength: 50, nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    LimitDate = table.Column<DateTime>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    IdentityId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIS_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SIS_Task_SIS_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "SIS_Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SIS_Task_SEC_Identity_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "SEC_Identity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SIS_Task_CFG_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "CFG_Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LOC_City_StateId",
                table: "LOC_City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_SIS_Client_CityId",
                table: "SIS_Client",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_SIS_Task_ClientId",
                table: "SIS_Task",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SIS_Task_IdentityId",
                table: "SIS_Task",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_SIS_Task_StatusId",
                table: "SIS_Task",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SIS_Task");

            migrationBuilder.DropTable(
                name: "SIS_Client");

            migrationBuilder.DropTable(
                name: "CFG_Status");

            migrationBuilder.DropTable(
                name: "LOC_City");

            migrationBuilder.DropTable(
                name: "LOC_State");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "SEC_Identity");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "SEC_Identity");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "SEC_Identity");
        }
    }
}
