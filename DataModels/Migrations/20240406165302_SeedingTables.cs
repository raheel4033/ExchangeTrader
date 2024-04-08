using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExchangeTrader.Migrations
{
    /// <inheritdoc />
    public partial class SeedingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "tickSize",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)");

            migrationBuilder.AlterColumn<string>(
                name: "field",
                table: "Products",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "productID", "Description", "Symbol", "field", "lotSize", "qouteCurrency", "settleCurrency", "tickSize" },
                values: new object[,]
                {
                    { 1, "Apple Inc. Common Stock", "AAPL", null, 100, "USD", "PKR", 0.01m },
                    { 2, "Google LLC Class C Capital Stock", "GOOGL", null, 100, "INR", "USD", 0.05m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "accountID", "broker", "clientOrderId", "entryTime", "orderStatus", "orderType", "price", "productID", "quantity", "side", "symbol", "timeInForce", "transactionTime", "userId" },
                values: new object[,]
                {
                    { 1, "1", "Interactive Brokers", "AB12", 1234L, "Open", "Market", 15000L, 1, 200L, "Buy", "AAPL", "GTC", 55L, 1L },
                    { 2, "2", "Raheel Investors", "XZ31", 1234L, "Open", "Market", 20000L, 2, 100L, "Sell", "GOOGL", "Day", 23L, 2L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "productID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "productID",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "tickSize",
                table: "Products",
                type: "nvarchar(3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "field",
                table: "Products",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);
        }
    }
}
