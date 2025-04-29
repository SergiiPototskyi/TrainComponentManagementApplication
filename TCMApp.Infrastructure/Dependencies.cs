using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TCMApp.Core.Interfaces;
using TCMApp.Infrastructure.Repositories;

namespace TCMApp.Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureDataDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITrainComponentRepository, TrainComponentRepository>();
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
