using System;
using System.Collections.Generic;
using Lokata.TrialDb.Models;
using Microsoft.EntityFrameworkCore;

namespace Lokata.Domain;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Approach> Approaches { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<Competition1> Competitions1 { get; set; }

    public virtual DbSet<Competitor> Competitors { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<ScoreCard> ScoreCards { get; set; }

    public virtual DbSet<Sex> Sexes { get; set; }

    public virtual DbSet<TakePlace> TakePlaces { get; set; }

    public virtual DbSet<TargetsAndCardsPhoto> TargetsAndCardsPhotos { get; set; }

    public virtual DbSet<TargetsOrCardTake> TargetsOrCardTakes { get; set; }

    public virtual DbSet<Umpire> Umpires { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Trusted_Connection=True;Integrated Security=True;Database=LOKataTrial;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.FullName).HasMaxLength(254);
            entity.Property(e => e.Number).HasMaxLength(50);
            entity.Property(e => e.PostalCode).HasMaxLength(50);
            entity.Property(e => e.PostalPlace).HasMaxLength(254);
            entity.Property(e => e.Street).HasMaxLength(254);
        });

        modelBuilder.Entity<Approach>(entity =>
        {
            entity.ToTable("Approach");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Competition).WithMany(p => p.Approaches)
                .HasForeignKey(d => d.CompetitionId)
                .HasConstraintName("FK_Approach_Competition");

            entity.HasOne(d => d.Competitions).WithMany(p => p.Approaches)
                .HasForeignKey(d => d.CompetitionsId)
                .HasConstraintName("FK_Approach_Competitions");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Approaches)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK_Approach_Instructor");

            entity.HasOne(d => d.Umpire).WithMany(p => p.Approaches)
                .HasForeignKey(d => d.UmpireId)
                .HasConstraintName("FK_Approach_Umpire");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(255);
        });

        modelBuilder.Entity<Competition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Comptition");

            entity.ToTable("Competition");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Competition1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Competition");

            entity.ToTable("Competitions");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Place).WithMany(p => p.Competition1s)
                .HasForeignKey(d => d.PlaceId)
                .HasConstraintName("FK_Competitions_Place");
        });

        modelBuilder.Entity<Competitor>(entity =>
        {
            entity.ToTable("Competitor");

            entity.Property(e => e.FullName).HasMaxLength(255);

            entity.HasOne(d => d.SexNavigation).WithMany(p => p.Competitors)
                .HasForeignKey(d => d.Sex)
                .HasConstraintName("FK_Competitor_Sex");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.ToTable("Document");

            entity.Property(e => e.Filename)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsFixedLength();
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.ToTable("Instructor");

            entity.Property(e => e.FullName).HasMaxLength(255);
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.ToTable("Place");

            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Places)
                .HasForeignKey(d => d.Address)
                .HasConstraintName("FK_Place_Address");
        });

        modelBuilder.Entity<ScoreCard>(entity =>
        {
            entity.ToTable("ScoreCard");

            entity.HasOne(d => d.Approach).WithMany(p => p.ScoreCards)
                .HasForeignKey(d => d.ApproachId)
                .HasConstraintName("FK_ScoreCard_Approach");

            entity.HasOne(d => d.Competitor).WithMany(p => p.ScoreCards)
                .HasForeignKey(d => d.CompetitorId)
                .HasConstraintName("FK_ScoreCard_Competitor");
        });

        modelBuilder.Entity<Sex>(entity =>
        {
            entity.ToTable("Sex");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TakePlace>(entity =>
        {
            entity.ToTable("TakePlace");

            entity.HasOne(d => d.Approach).WithMany(p => p.TakePlaces)
                .HasForeignKey(d => d.ApproachId)
                .HasConstraintName("FK_TakePlace_Approach");

            entity.HasOne(d => d.Competitor).WithMany(p => p.TakePlaces)
                .HasForeignKey(d => d.CompetitorId)
                .HasConstraintName("FK_TakePlace_Competitor");
        });

        modelBuilder.Entity<TargetsAndCardsPhoto>(entity =>
        {
            entity.ToTable("TargetsAndCardsPhoto");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Aproach).WithMany(p => p.TargetsAndCardsPhotos)
                .HasForeignKey(d => d.AproachId)
                .HasConstraintName("FK_TargetsAndCardsPhoto_Approach");

            entity.HasOne(d => d.Competitor).WithMany(p => p.TargetsAndCardsPhotos)
                .HasForeignKey(d => d.CompetitorId)
                .HasConstraintName("FK_TargetsAndCardsPhoto_Competitor");
        });

        modelBuilder.Entity<TargetsOrCardTake>(entity =>
        {
            entity.ToTable("TargetsOrCardTake");

            entity.HasOne(d => d.Approach).WithMany(p => p.TargetsOrCardTakes)
                .HasForeignKey(d => d.ApproachId)
                .HasConstraintName("FK_TargetsOrCardTake_Approach");

            entity.HasOne(d => d.Competitor).WithMany(p => p.TargetsOrCardTakes)
                .HasForeignKey(d => d.CompetitorId)
                .HasConstraintName("FK_TargetsOrCardTake_Competitor");
        });

        modelBuilder.Entity<Umpire>(entity =>
        {
            entity.ToTable("Umpire");

            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.PermissionDocumentNumber).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
