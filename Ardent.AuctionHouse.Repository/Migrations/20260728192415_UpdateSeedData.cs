using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ardent.AuctionHouse.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("01dbc921-a06e-43cf-82d0-b1e6532f2a2c"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ca3d3541-cbda-4728-a923-454da8f4bd89"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("f107df23-f65d-4cbb-ab7b-20bb4276b57d"));

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Location", "Name", "Showings" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 7, 31, 0, 0, 0, 0, DateTimeKind.Utc), "London", "Rare Watch Collection Auction", "[]" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), "London", "Fine Art Auction", "[]" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 8, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Manchester", "Classic Car Auction", "[]" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Location", "Name", "Showings" },
                values: new object[,]
                {
                    { new Guid("01dbc921-a06e-43cf-82d0-b1e6532f2a2c"), new DateTime(2026, 8, 4, 19, 21, 19, 583, DateTimeKind.Utc).AddTicks(8434), "Manchester", "Classic Car Auction", "[]" },
                    { new Guid("ca3d3541-cbda-4728-a923-454da8f4bd89"), new DateTime(2026, 7, 31, 19, 21, 19, 583, DateTimeKind.Utc).AddTicks(7393), "London", "Rare Watch Collection Auction", "[]" },
                    { new Guid("f107df23-f65d-4cbb-ab7b-20bb4276b57d"), new DateTime(2026, 8, 18, 19, 21, 19, 583, DateTimeKind.Utc).AddTicks(8426), "London", "Fine Art Auction", "[]" }
                });
        }
    }
}
