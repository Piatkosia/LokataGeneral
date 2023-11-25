using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lokata.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostalPlace = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MinAgeInYears = table.Column<int>(type: "int", nullable: false),
                    MaxAgeInYears = table.Column<int>(type: "int", nullable: true),
                    ForDisabled = table.Column<bool>(type: "bit", nullable: false),
                    ForProfessional = table.Column<bool>(type: "bit", nullable: false),
                    ForFemale = table.Column<bool>(type: "bit", nullable: false),
                    ForMale = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SeriesCount = table.Column<int>(type: "int", nullable: true),
                    MaxPointsPerSeries = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    Filename = table.Column<string>(type: "nchar(255)", fixedLength: true, maxLength: 255, nullable: true),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    DocumentValidUntil = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AsMale = table.Column<bool>(type: "bit", nullable: false),
                    AsFemale = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sex", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Umpire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PermissionDocumentNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PermissionDocumentDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PermissionValidUntil = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Umpire", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<int>(type: "int", nullable: true),
                    ShootingPlacesCount = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Place_Address",
                        column: x => x.Address,
                        principalTable: "Address",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Competitor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    IsDisabledPerson = table.Column<bool>(type: "bit", nullable: true),
                    Professional = table.Column<bool>(type: "bit", nullable: true),
                    SexId = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitor_Sex",
                        column: x => x.SexId,
                        principalTable: "Sex",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitions_Place",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Approach",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitionId = table.Column<int>(type: "int", nullable: true),
                    CompetitionsId = table.Column<int>(type: "int", nullable: true),
                    InstructorId = table.Column<int>(type: "int", nullable: true),
                    UmpireId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approach", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Approach_Competition",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Approach_Competitions",
                        column: x => x.CompetitionsId,
                        principalTable: "Competitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Approach_Instructor",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Approach_Umpire",
                        column: x => x.UmpireId,
                        principalTable: "Umpire",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ScoreCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitorId = table.Column<int>(type: "int", nullable: true),
                    ApproachId = table.Column<int>(type: "int", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoreCard_Approach",
                        column: x => x.ApproachId,
                        principalTable: "Approach",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScoreCard_Competitor",
                        column: x => x.CompetitorId,
                        principalTable: "Competitor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TakePlace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitorId = table.Column<int>(type: "int", nullable: true),
                    ApproachId = table.Column<int>(type: "int", nullable: true),
                    TookPlace = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakePlace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TakePlace_Approach",
                        column: x => x.ApproachId,
                        principalTable: "Approach",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TakePlace_Competitor",
                        column: x => x.CompetitorId,
                        principalTable: "Competitor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TargetsAndCardsPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproachId = table.Column<int>(type: "int", nullable: true),
                    CompetitorId = table.Column<int>(type: "int", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetsAndCardsPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TargetsAndCardsPhoto_Approach",
                        column: x => x.ApproachId,
                        principalTable: "Approach",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TargetsAndCardsPhoto_Competitor",
                        column: x => x.CompetitorId,
                        principalTable: "Competitor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TargetsOrCardTake",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitorId = table.Column<int>(type: "int", nullable: true),
                    ApproachId = table.Column<int>(type: "int", nullable: true),
                    CardOrTargetTaken = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetsOrCardTake", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TargetsOrCardTake_Approach",
                        column: x => x.ApproachId,
                        principalTable: "Approach",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TargetsOrCardTake_Competitor",
                        column: x => x.CompetitorId,
                        principalTable: "Competitor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Approach_CompetitionId",
                table: "Approach",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Approach_CompetitionsId",
                table: "Approach",
                column: "CompetitionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Approach_InstructorId",
                table: "Approach",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Approach_UmpireId",
                table: "Approach",
                column: "UmpireId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_PlaceId",
                table: "Competitions",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitor_SexId",
                table: "Competitor",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_Address",
                table: "Place",
                column: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCard_ApproachId",
                table: "ScoreCard",
                column: "ApproachId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCard_CompetitorId",
                table: "ScoreCard",
                column: "CompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_TakePlace_ApproachId",
                table: "TakePlace",
                column: "ApproachId");

            migrationBuilder.CreateIndex(
                name: "IX_TakePlace_CompetitorId",
                table: "TakePlace",
                column: "CompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetsAndCardsPhoto_ApproachId",
                table: "TargetsAndCardsPhoto",
                column: "ApproachId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetsAndCardsPhoto_CompetitorId",
                table: "TargetsAndCardsPhoto",
                column: "CompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetsOrCardTake_ApproachId",
                table: "TargetsOrCardTake",
                column: "ApproachId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetsOrCardTake_CompetitorId",
                table: "TargetsOrCardTake",
                column: "CompetitorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "ScoreCard");

            migrationBuilder.DropTable(
                name: "TakePlace");

            migrationBuilder.DropTable(
                name: "TargetsAndCardsPhoto");

            migrationBuilder.DropTable(
                name: "TargetsOrCardTake");

            migrationBuilder.DropTable(
                name: "Approach");

            migrationBuilder.DropTable(
                name: "Competitor");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Umpire");

            migrationBuilder.DropTable(
                name: "Sex");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
