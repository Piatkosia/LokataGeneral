using Lokata.DataAccess;
using Lokata.DataService;
using Lokata.Domain.Converters;
using Lokata.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lokata.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.Converters.Add(new JsonDateOnlyConverter());
                options.JsonSerializerOptions.Converters.Add(new JsonNullableDateOnlyConverter());
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection"));
            });
            AddDomainServices(builder.Services);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

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
            services.AddScoped<IUmpireService, UmpireService>();
            services.AddScoped<IInstructorDocumentService, InstructorDocumentService>();
        }
    }
}
