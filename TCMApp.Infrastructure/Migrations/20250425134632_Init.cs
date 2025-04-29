#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

using Microsoft.EntityFrameworkCore.Migrations;

namespace TCMApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tcm");

            migrationBuilder.CreateTable(
                name: "TrainComponents",
                schema: "tcm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UniqueNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CanAssignQuantity = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainComponents", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "tcm",
                table: "TrainComponents",
                columns: new[] { "Id", "CanAssignQuantity", "Name", "Quantity", "UniqueNumber" },
                values: new object[,]
                {
                    { 1, false, "Engine", null, "ENG123" },
                    { 2, false, "Passenger Car", null, "PAS456" },
                    { 3, false, "Freight Car", null, "FRT789" },
                    { 4, true, "Wheel", 68, "WHL101" },
                    { 5, true, "Seat", 59, "STS234" },
                    { 6, true, "Window", 15, "WIN567" },
                    { 7, true, "Door", 71, "DR123" },
                    { 8, true, "Control Panel", 82, "CTL987" },
                    { 9, true, "Light", 65, "LGT456" },
                    { 10, true, "Brake", 50, "BRK789" },
                    { 11, true, "Bolt", 6, "BLT321" },
                    { 12, true, "Nut", 26, "NUT654" },
                    { 13, false, "Engine Hood", null, "EH789" },
                    { 14, false, "Axle", null, "AX456" },
                    { 15, false, "Piston", null, "PST789" },
                    { 16, true, "Handrail", 49, "HND234" },
                    { 17, true, "Step", 86, "STP567" },
                    { 18, false, "Roof", null, "RF123" },
                    { 19, false, "Air Conditioner", null, "AC789" },
                    { 20, false, "Flooring", null, "FLR456" },
                    { 21, true, "Mirror", 7, "MRR789" },
                    { 22, false, "Horn", null, "HRN321" },
                    { 23, false, "Coupler", null, "CPL654" },
                    { 24, true, "Hinge", 43, "HNG987" },
                    { 25, true, "Ladder", 53, "LDR456" },
                    { 26, false, "Paint", null, "PNT789" },
                    { 27, true, "Decal", 23, "DCL321" },
                    { 28, true, "Gauge", 10, "GGS654" },
                    { 29, false, "Battery", null, "BTR987" },
                    { 30, false, "Radiator", null, "RDR456" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainComponents_UniqueNumber",
                schema: "tcm",
                table: "TrainComponents",
                column: "UniqueNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainComponents",
                schema: "tcm");
        }
    }
}
