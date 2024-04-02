using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExchangeTrader.Migrations
{
    /// <inheritdoc />
    public partial class AddProductAndOrderTableToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    lotSize = table.Column<int>(type: "int", nullable: false),
                    tickSize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    qouteCurrency = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    settleCurrency = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    field = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productID = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<long>(type: "bigint", nullable: false),
                    quantity = table.Column<long>(type: "bigint", nullable: false),
                    side = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    orderStatus = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    orderType = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    timeInForce = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    symbol = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    userId = table.Column<long>(type: "bigint", nullable: true),
                    clientOrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    broker = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    accountID = table.Column<long>(type: "bigint", nullable: false),
                    entryTime = table.Column<long>(type: "bigint", nullable: false),
                    transactionTime = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Products_productID",
                        column: x => x.productID,
                        principalTable: "Products",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 1, 1L, "Interactive Brokers", "AB12", 1234L, "Open", "Market", 15000L, 1, 200L, "Buy", "AAPL", "GTC", 55L, 1L },
                    { 2, 2L, "Raheel Investors", "XZ31", 1234L, "Open", "Market", 20000L, 2, 100L, "Sell", "GOOGL", "Day", 23L, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_productID",
                table: "Orders",
                column: "productID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
