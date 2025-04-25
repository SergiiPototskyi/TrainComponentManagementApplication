using Microsoft.EntityFrameworkCore;

namespace TCMApp.Server.Data;

public static class Dependencies
{
    public static void AddDbContext(this WebApplicationBuilder builder)
    {
        if (!builder.Environment.IsDevelopment())
        {
            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseInMemoryDatabase("TrainDatabase"));
        }
        else
        {
            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection") 
                    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
        }

    }
}
