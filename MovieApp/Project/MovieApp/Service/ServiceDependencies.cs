using Microsoft.Extensions.DependencyInjection;
using Service.Abstract;
using Service.BusinessRules;
using Service.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

public static class ServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IPlatformService, PlatformService>();
        services.AddScoped<IMovieService, MovieService>();

        services.AddScoped<PlatformRules>();
        services.AddScoped<MovieRules>();
        services.AddScoped<CategoryRules>();

        return services;
    }
}
