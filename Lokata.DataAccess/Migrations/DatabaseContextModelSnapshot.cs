﻿// <auto-generated />
using System;
using Lokata.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lokata.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DocumentInstructor", b =>
                {
                    b.Property<int>("DocumentsId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorsId")
                        .HasColumnType("int");

                    b.HasKey("DocumentsId", "InstructorsId");

                    b.HasIndex("InstructorsId");

                    b.ToTable("DocumentInstructor");
                });

            modelBuilder.Entity("Lokata.Domain.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostalPlace")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("Street")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.HasKey("Id");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("Lokata.Domain.Approach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<int?>("CompetitionsId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UmpireId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("CompetitionsId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("UmpireId");

                    b.ToTable("Approach", (string)null);
                });

            modelBuilder.Entity("Lokata.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ForDisabled")
                        .HasColumnType("bit");

                    b.Property<bool>("ForFemale")
                        .HasColumnType("bit");

                    b.Property<bool>("ForMale")
                        .HasColumnType("bit");

                    b.Property<bool>("ForProfessional")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("MaxAgeInYears")
                        .HasColumnType("int");

                    b.Property<int>("MinAgeInYears")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Lokata.Domain.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("MaxPointsPerSeries")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("SeriesCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Competition", (string)null);
                });

            modelBuilder.Entity("Lokata.Domain.Competitions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly?>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Competitions", (string)null);
                });

            modelBuilder.Entity("Lokata.Domain.Competitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FullName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDisabledPerson")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Professional")
                        .HasColumnType("bit");

                    b.Property<int?>("SexId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SexId");

                    b.ToTable("Competitor", (string)null);
                });

            modelBuilder.Entity("Lokata.Domain.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("FileContent")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Filename")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Document", (string)null);
                });

            modelBuilder.Entity("Lokata.Domain.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly?>("DocumentValidUntil")
                        .HasColumnType("date");

                    b.Property<string>("FullName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Instructor", (string)null);
                });

            modelBuilder.Entity("Lokata.Domain.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Address")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShootingPlacesCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Address");

                    b.ToTable("Place", (string)null);
                });

            modelBuilder.Entity("Lokata.Domain.ScoreCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApproachId")
                        .HasColumnType("int");

                    b.Property<int?>("CompetitorId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApproachId");

                    b.HasIndex("CompetitorId");

                    b.ToTable("ScoreCard", (string)null);
                });

            modelBuilder.Entity("Lokata.Domain.Sex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AsFemale")
                        .HasColumnType("bit");

                    b.Property<bool>("AsMale")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Sex", (string)null);
                });

            modelBuilder.Entity("Lokata.Domain.TakePlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApproachId")
                        .HasColumnType("int");

                    b.Property<int?>("CompetitorId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("TookPlace")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ApproachId");

                    b.HasIndex("CompetitorId");

                    b.ToTable("TakePlace", (string)null);
                });

            modelBuilder.Entity("Lokata.Domain.TargetsAndCardsPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApproachId")
                        .HasColumnType("int");

                    b.Property<int?>("CompetitorId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApproachId");

                    b.HasIndex("CompetitorId");

                    b.ToTable("TargetsAndCardsPhoto", (string)null);
                });

            modelBuilder.Entity("Lokata.Domain.TargetsOrCardTake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApproachId")
                        .HasColumnType("int");

                    b.Property<bool?>("CardOrTargetTaken")
                        .HasColumnType("bit");

                    b.Property<int?>("CompetitorId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApproachId");

                    b.HasIndex("CompetitorId");

                    b.ToTable("TargetsOrCardTake", (string)null);
                });

            modelBuilder.Entity("Lokata.Domain.Umpire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly?>("PermissionDocumentDate")
                        .HasColumnType("date");

                    b.Property<string>("PermissionDocumentNumber")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateOnly?>("PermissionValidUntil")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Umpire", (string)null);
                });

            modelBuilder.Entity("DocumentInstructor", b =>
                {
                    b.HasOne("Lokata.Domain.Document", null)
                        .WithMany()
                        .HasForeignKey("DocumentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lokata.Domain.Instructor", null)
                        .WithMany()
                        .HasForeignKey("InstructorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lokata.Domain.Approach", b =>
                {
                    b.HasOne("Lokata.Domain.Competition", "Competition")
                        .WithMany("Approaches")
                        .HasForeignKey("CompetitionId")
                        .HasConstraintName("FK_Approach_Competition");

                    b.HasOne("Lokata.Domain.Competitions", "Competitions")
                        .WithMany("Approaches")
                        .HasForeignKey("CompetitionsId")
                        .HasConstraintName("FK_Approach_Competitions");

                    b.HasOne("Lokata.Domain.Instructor", "Instructor")
                        .WithMany("Approaches")
                        .HasForeignKey("InstructorId")
                        .HasConstraintName("FK_Approach_Instructor");

                    b.HasOne("Lokata.Domain.Umpire", "Umpire")
                        .WithMany("Approaches")
                        .HasForeignKey("UmpireId")
                        .HasConstraintName("FK_Approach_Umpire");

                    b.Navigation("Competition");

                    b.Navigation("Competitions");

                    b.Navigation("Instructor");

                    b.Navigation("Umpire");
                });

            modelBuilder.Entity("Lokata.Domain.Competitions", b =>
                {
                    b.HasOne("Lokata.Domain.Place", "Place")
                        .WithMany("CompetitionsList")
                        .HasForeignKey("PlaceId")
                        .HasConstraintName("FK_Competitions_Place");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("Lokata.Domain.Competitor", b =>
                {
                    b.HasOne("Lokata.Domain.Sex", "Sex")
                        .WithMany("CompetitorList")
                        .HasForeignKey("SexId")
                        .HasConstraintName("FK_Competitor_Sex");

                    b.Navigation("Sex");
                });

            modelBuilder.Entity("Lokata.Domain.Place", b =>
                {
                    b.HasOne("Lokata.Domain.Address", "AddressNavigation")
                        .WithMany("Places")
                        .HasForeignKey("Address")
                        .HasConstraintName("FK_Place_Address");

                    b.Navigation("AddressNavigation");
                });

            modelBuilder.Entity("Lokata.Domain.ScoreCard", b =>
                {
                    b.HasOne("Lokata.Domain.Approach", "Approach")
                        .WithMany("ScoreCards")
                        .HasForeignKey("ApproachId")
                        .HasConstraintName("FK_ScoreCard_Approach");

                    b.HasOne("Lokata.Domain.Competitor", "Competitor")
                        .WithMany("ScoreCards")
                        .HasForeignKey("CompetitorId")
                        .HasConstraintName("FK_ScoreCard_Competitor");

                    b.Navigation("Approach");

                    b.Navigation("Competitor");
                });

            modelBuilder.Entity("Lokata.Domain.TakePlace", b =>
                {
                    b.HasOne("Lokata.Domain.Approach", "Approach")
                        .WithMany("TakePlaces")
                        .HasForeignKey("ApproachId")
                        .HasConstraintName("FK_TakePlace_Approach");

                    b.HasOne("Lokata.Domain.Competitor", "Competitor")
                        .WithMany("TakePlaces")
                        .HasForeignKey("CompetitorId")
                        .HasConstraintName("FK_TakePlace_Competitor");

                    b.Navigation("Approach");

                    b.Navigation("Competitor");
                });

            modelBuilder.Entity("Lokata.Domain.TargetsAndCardsPhoto", b =>
                {
                    b.HasOne("Lokata.Domain.Approach", "Approach")
                        .WithMany("TargetsAndCardsPhotos")
                        .HasForeignKey("ApproachId")
                        .HasConstraintName("FK_TargetsAndCardsPhoto_Approach");

                    b.HasOne("Lokata.Domain.Competitor", "Competitor")
                        .WithMany("TargetsAndCardsPhotos")
                        .HasForeignKey("CompetitorId")
                        .HasConstraintName("FK_TargetsAndCardsPhoto_Competitor");

                    b.Navigation("Approach");

                    b.Navigation("Competitor");
                });

            modelBuilder.Entity("Lokata.Domain.TargetsOrCardTake", b =>
                {
                    b.HasOne("Lokata.Domain.Approach", "Approach")
                        .WithMany("TargetsOrCardTakes")
                        .HasForeignKey("ApproachId")
                        .HasConstraintName("FK_TargetsOrCardTake_Approach");

                    b.HasOne("Lokata.Domain.Competitor", "Competitor")
                        .WithMany("TargetsOrCardTakes")
                        .HasForeignKey("CompetitorId")
                        .HasConstraintName("FK_TargetsOrCardTake_Competitor");

                    b.Navigation("Approach");

                    b.Navigation("Competitor");
                });

            modelBuilder.Entity("Lokata.Domain.Address", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("Lokata.Domain.Approach", b =>
                {
                    b.Navigation("ScoreCards");

                    b.Navigation("TakePlaces");

                    b.Navigation("TargetsAndCardsPhotos");

                    b.Navigation("TargetsOrCardTakes");
                });

            modelBuilder.Entity("Lokata.Domain.Competition", b =>
                {
                    b.Navigation("Approaches");
                });

            modelBuilder.Entity("Lokata.Domain.Competitions", b =>
                {
                    b.Navigation("Approaches");
                });

            modelBuilder.Entity("Lokata.Domain.Competitor", b =>
                {
                    b.Navigation("ScoreCards");

                    b.Navigation("TakePlaces");

                    b.Navigation("TargetsAndCardsPhotos");

                    b.Navigation("TargetsOrCardTakes");
                });

            modelBuilder.Entity("Lokata.Domain.Instructor", b =>
                {
                    b.Navigation("Approaches");
                });

            modelBuilder.Entity("Lokata.Domain.Place", b =>
                {
                    b.Navigation("CompetitionsList");
                });

            modelBuilder.Entity("Lokata.Domain.Sex", b =>
                {
                    b.Navigation("CompetitorList");
                });

            modelBuilder.Entity("Lokata.Domain.Umpire", b =>
                {
                    b.Navigation("Approaches");
                });
#pragma warning restore 612, 618
        }
    }
}
