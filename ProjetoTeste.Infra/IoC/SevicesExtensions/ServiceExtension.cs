using Microsoft.Extensions.DependencyInjection;
using ProjetoTeste.Infra.Services.Abstraction;
using ProjetoTeste.Infra.Services.Implementation;
using ProjetoTeste.Infra.UoW;

namespace ProjetoTeste.Infra.IoC.SevicesExtensions
{
    public static class ServiceExtension
    {
        public static void AddRegisterService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
