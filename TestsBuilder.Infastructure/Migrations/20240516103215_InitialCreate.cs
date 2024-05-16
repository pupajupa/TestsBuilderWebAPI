using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestsBuilder.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Examples",
                columns: table => new
                {
                    ExampleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BaseAnswers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examples", x => new { x.ExampleId, x.TestId });
                    table.ForeignKey(
                        name: "FK_Examples_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExampleVariants",
                columns: table => new
                {
                    ExampleVariantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExampleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Expression = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Answers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleVariants", x => new { x.ExampleVariantId, x.ExampleId, x.TestId });
                    table.ForeignKey(
                        name: "FK_ExampleVariants_Examples_ExampleId_TestId",
                        columns: x => new { x.ExampleId, x.TestId },
                        principalTable: "Examples",
                        principalColumns: new[] { "ExampleId", "TestId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examples_TestId",
                table: "Examples",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleVariants_ExampleId_TestId",
                table: "ExampleVariants",
                columns: new[] { "ExampleId", "TestId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExampleVariants");

            migrationBuilder.DropTable(
                name: "Examples");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
