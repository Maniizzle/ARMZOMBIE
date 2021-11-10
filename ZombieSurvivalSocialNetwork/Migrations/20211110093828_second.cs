using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZombieSurvivalSocialNetwork.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "SurvivorsRequestAndResponseResource");

            migrationBuilder.DropTable(
                name: "SurvivorsTrades");
        }
    }
}
