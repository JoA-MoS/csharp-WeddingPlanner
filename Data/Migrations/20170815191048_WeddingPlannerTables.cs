using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingPlanner.Migrations
{
    public partial class WeddingPlannerTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weddings",
                columns: table => new
                {
                    WeddingId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Address = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedById = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    WedderOne = table.Column<string>(nullable: true),
                    WedderTwo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weddings", x => x.WeddingId);
                    table.ForeignKey(
                        name: "FK_Weddings_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weddings_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weddings_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WedddingGuests",
                columns: table => new
                {
                    WeddingGuestId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    GuestId = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedById = table.Column<string>(nullable: true),
                    WeddingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WedddingGuests", x => x.WeddingGuestId);
                    table.ForeignKey(
                        name: "FK_WedddingGuests_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WedddingGuests_AspNetUsers_GuestId",
                        column: x => x.GuestId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WedddingGuests_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WedddingGuests_Weddings_WeddingId",
                        column: x => x.WeddingId,
                        principalTable: "Weddings",
                        principalColumn: "WeddingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_CreatedById",
                table: "Weddings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_ModifiedById",
                table: "Weddings",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_OwnerId",
                table: "Weddings",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_WedddingGuests_CreatedById",
                table: "WedddingGuests",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WedddingGuests_GuestId",
                table: "WedddingGuests",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_WedddingGuests_ModifiedById",
                table: "WedddingGuests",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_WedddingGuests_WeddingId",
                table: "WedddingGuests",
                column: "WeddingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WedddingGuests");

            migrationBuilder.DropTable(
                name: "Weddings");
        }
    }
}
