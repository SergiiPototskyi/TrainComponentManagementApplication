using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                values: new object[] { 1, false, "Engine", null, "ENG123" });

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
