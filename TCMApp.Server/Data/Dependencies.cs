using Microsoft.EntityFrameworkCore;
using TCMApp.Server.Core.Interfaces;
using TCMApp.Server.Data.Repositories;

namespace TCMApp.Server.Data
{
    public static class Dependencies
    {
        public static void ConfigureDataDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ITrainComponentRepository, TrainComponentRepository>();
        }

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using ApplicationContext context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

            context.Database.EnsureCreated();
            context.Database.Migrate();
        }
    }
}
