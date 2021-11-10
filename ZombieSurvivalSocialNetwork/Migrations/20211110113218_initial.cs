using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZombieSurvivalSocialNetwork.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfectionReports",
                columns: table => new
                {
                    ReportingSurvivor = table.Column<int>(type: "INTEGER", nullable: false),
                    ReportedSurvivor = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfectionReports", x => new { x.ReportedSurvivor, x.ReportingSurvivor });
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Point = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Survivors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    LastLocation = table.Column<string>(type: "TEXT", nullable: true),
                    IsInfected = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateInfected = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survivors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurvivorsTrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestingSurvivior = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestedSurvivior = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfTrade = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurvivorsTrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurvivorItems",
                columns: table => new
                {
                    SurvivorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurvivorItems", x => new { x.ItemId, x.SurvivorId });
                    table.ForeignKey(
                        name: "FK_SurvivorItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurvivorItems_Survivors_SurvivorId",
                        column: x => x.SurvivorId,
                        principalTable: "Survivors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurvivorsRequestAndResponseResource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Point = table.Column<int>(type: "INTEGER", nullable: false),
                    IsResponse = table.Column<bool>(type: "INTEGER", nullable: false),
                    SurvivorsTradeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurvivorsRequestAndResponseResource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurvivorsRequestAndResponseResource_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurvivorsRequestAndResponseResource_SurvivorsTrades_SurvivorsTradeId",
                        column: x => x.SurvivorsTradeId,
                        principalTable: "SurvivorsTrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "Point" },
                values: new object[] { 1, "Water", 4 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "Point" },
                values: new object[] { 2, "Food", 3 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "Point" },
                values: new object[] { 3, "Medication", 2 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "Point" },
                values: new object[] { 4, "Ammunition", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_SurvivorItems_SurvivorId",
                table: "SurvivorItems",
                column: "SurvivorId");

            migrationBuilder.CreateIndex(
                name: "IX_Survivors_IsInfected",
                table: "Survivors",
                column: "IsInfected");

            migrationBuilder.CreateIndex(
                name: "IX_SurvivorsRequestAndResponseResource_ItemId",
                table: "SurvivorsRequestAndResponseResource",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SurvivorsRequestAndResponseResource_SurvivorsTradeId",
                table: "SurvivorsRequestAndResponseResource",
                column: "SurvivorsTradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfectionReports");

            migrationBuilder.DropTable(
                name: "SurvivorItems");

            migrationBuilder.DropTable(
                name: "SurvivorsRequestAndResponseResource");

            migrationBuilder.DropTable(
                name: "Survivors");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "SurvivorsTrades");
        }
    }
}
