using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductApp.DataAccess.Products;
using ProductApp.Services.Products;


namespace ProductApp.Services.Extensions;

public static class ServicesExtensions
{

    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
