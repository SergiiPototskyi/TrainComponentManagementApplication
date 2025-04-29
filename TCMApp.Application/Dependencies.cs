using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TCMApp.Application.Mappers;
using TCMApp.Application.UseCases.AddTrainComponent;
using TCMApp.Application.UseCases.Models;
using TCMApp.Application.UseCases.UpdateTrainComponent;
using TCMApp.Application.UseCases.Validators;
using TCMApp.Core.Entities;
using TCMApp.Core.Interfaces;

namespace TCMApp.Application
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
