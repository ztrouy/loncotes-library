using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoncotesLibrary.Migrations
{
    /// <inheritdoc />
    public partial class PaidCheckouts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Checkouts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Paid",
                value: true);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Paid",
                value: true);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 9,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 10,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 11,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 12,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 13,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 14,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 15,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 16,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 17,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 18,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 19,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 20,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 21,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 22,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 23,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 24,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 25,
                column: "Paid",
                value: false);

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 26,
                column: "Paid",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Checkouts");
        }
    }
}
