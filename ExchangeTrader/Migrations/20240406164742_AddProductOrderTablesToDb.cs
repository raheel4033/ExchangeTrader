using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeTrader.Migrations
{
    /// <inheritdoc />
    public partial class AddProductOrderTablesToDb : Migration
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
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lotSize = table.Column<int>(type: "int", nullable: false),
                    tickSize = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    qouteCurrency = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    settleCurrency = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    field = table.Column<string>(type: "nvarchar(20)", nullable: false)
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
                    clientOrderId = table.Column<string>(type: "nvarchar(8)", nullable: true),
                    broker = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    accountID = table.Column<string>(type: "nvarchar(8)", nullable: false),
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
