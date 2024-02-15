using Lokata.DataAccess.TypeConfigurations;
using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lokata.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Approach> Approaches { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Competition> Competitions { get; set; }

        public virtual DbSet<Competitions> CompetitionsList { get; set; }

        public virtual DbSet<Competitor> Competitors { get; set; }

        public virtual DbSet<Document> Documents { get; set; }

        public virtual DbSet<Instructor> Instructors { get; set; }

        public virtual DbSet<Place> Places { get; set; }

        public virtual DbSet<ScoreCard> ScoreCards { get; set; }

        public virtual DbSet<Sex> Sexes { get; set; }

        public virtual DbSet<TakePlace> TakePlaces { get; set; }

        public virtual DbSet<TargetsAndCardsPhoto> TargetsAndCardsPhotos { get; set; }

        public virtual DbSet<TargetsOrCardTake> TargetsOrCardTakes { get; set; }
        public virtual DbSet<InstructorDocument> InstructorDocuments { get; set; }

        public virtual DbSet<Umpire> Umpires { get; set; }
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new ApproachConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CompetitionConfiguration());
            modelBuilder.ApplyConfiguration(new CompetitionsConfiguration());
            modelBuilder.ApplyConfiguration(new CompetitorConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorConfiguration());
            modelBuilder.ApplyConfiguration(new PlaceConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreCardConfiguration());
            modelBuilder.ApplyConfiguration(new SexConfiguration());
            modelBuilder.ApplyConfiguration(new TakePlaceConfiguration());
            modelBuilder.ApplyConfiguration(new TargetsAndCardsPhotoConfiguration());
            modelBuilder.ApplyConfiguration(new TargetsOrCardTakeConfiguration());
            modelBuilder.ApplyConfiguration(new UmpireConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("LocalConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
