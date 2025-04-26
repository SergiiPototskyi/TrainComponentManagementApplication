using FluentValidation;
using TCMApp.Server.Core.Entities;
using TCMApp.Server.Core.Interfaces;
using TCMApp.Server.Mappers;
using TCMApp.Server.UseCases.AddTrainComponent;
using TCMApp.Server.UseCases.Models;
using TCMApp.Server.UseCases.UpdateTrainComponent;
using TCMApp.Server.UseCases.Validators;

namespace TCMApp.Server
{
    public static class Dependencies
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Dependencies).Assembly));
            services.AddScoped<IMapper<TrainComponent, TrainComponentResponse>, TrainComponentMapper>();
            services.AddScoped<IValidator<AddTrainComponentRequest>, AddTrainComponentRequestValidator>();
            services.AddScoped<IValidator<UpdateTrainComponentRequest>, UpdateTrainComponentRequestValidator>();
        }
    }
}
