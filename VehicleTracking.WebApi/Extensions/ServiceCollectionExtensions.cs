using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.OpenApi.Models;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Application.IServices;
using VehicleTracking.Application.Pipelines;
using VehicleTracking.Persistence.Data;
using VehicleTracking.Persistence.Repositories;
using VehicleTracking.Persistence.Services;
using VehicleTracking.WebApi.Middleware;


namespace VehicleTracking.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddVehicleTrackingServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton(sp =>
            new DapperContext(configuration));
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<IDeviceCommandRepository, DeviceCommandRepository>();
        services.AddScoped<IDeviceCommandService, DeviceCommandService>();
        services.AddScoped<IDeviceService, DeviceService>();
        services.AddScoped<IDeviceRepository, DeviceRepository>();
        services.AddScoped<IDriverRepository, DriverRepository>();
        services.AddScoped<IDriverService, DriverService>();
        services.AddScoped<IReportRepository, ReportRepository>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthRepository, AuthRepository>();

        services.AddFluentValidationAutoValidation();

        services.AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient<ExceptionMiddleware>();

        IServiceCollection serviceCollection = services.AddAutoMapper(typeof(Application.AssemblyReference).Assembly);
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(
                typeof(Application.AssemblyReference).Assembly));

        services
            .AddControllers()
            .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c =>
          {
              c.SwaggerDoc("v1", new OpenApiInfo { Title = "VehicleTracking API", Version = "v1" });
              c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
              {
                  In = ParameterLocation.Header,
                  Name = "Authorization",
                  Type = SecuritySchemeType.ApiKey,
                  Description = "JWT Bearer token. Header'a 'Bearer {token}' formatında ekleyin."
              });
              c.AddSecurityRequirement(new OpenApiSecurityRequirement
  {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        Array.Empty<string>()
    }
  });
          });



        return services;
    }
}
