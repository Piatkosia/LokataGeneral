using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lokata.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Dodaniew2w : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Instructor");

            migrationBuilder.CreateTable(
                name: "DocumentInstructor",
                columns: table => new
                {
                    DocumentsId = table.Column<int>(type: "int", nullable: false),
                    InstructorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentInstructor", x => new { x.DocumentsId, x.InstructorsId });
                    table.ForeignKey(
                        name: "FK_DocumentInstructor_Document_DocumentsId",
                        column: x => x.DocumentsId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentInstructor_Instructor_InstructorsId",
                        column: x => x.InstructorsId,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentInstructor_InstructorsId",
                table: "DocumentInstructor",
                column: "InstructorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentInstructor");

            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "Instructor",
                type: "int",
                nullable: true);
        }
    }
}
