using TCMApp.Server.Core.Contracts;
using TCMApp.Server.Core.Entities;
using TCMApp.Server.Core.Interfaces;
using TCMApp.Server.Mappers;
using TCMApp.Server.Services;

namespace TCMApp.Server;

public static class Dependencies
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITrainComponentService, TrainComponentService>();
        services.AddScoped<IMapper<TrainComponent, TrainComponentContract>, TrainComponentMapper>();
    }
}
