
using Lokata.DataAccess;
using Lokata.DataService;
using Lokata.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Lokata.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection"));
            });
            AddDomainServices(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void AddDomainServices(IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IApproachService, ApproachService>();
            services.AddScoped<ITargetsAndCardsPhotoService, TargetsAndCardsPhotoService>();
            services.AddScoped<ITargetsOrCardTakeService, TargetsOrCardTakeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICompetitionService, CompetitionService>();
            services.AddScoped<ICompetitionsService, CompetitionsService>();
            services.AddScoped<ICompetitorService, CompetitorService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IInstructorService, InstructorService>();
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<IScoreCardService, ScoreCardService>();
            services.AddScoped<ISexService, SexService>();
            services.AddScoped<ITakePlaceService, TakePlaceService>();
            services.AddScoped<ITargetsAndCardsPhotoService, TargetsAndCardsPhotoService>();
            services.AddScoped<ITargetsOrCardTakeService, TargetsOrCardTakeService>();
        }
    }
}
