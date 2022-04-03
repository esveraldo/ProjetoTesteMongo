using Microsoft.Extensions.DependencyInjection;
using ProjetoTeste.Infra.Context;
using ProjetoTeste.Infra.Repositories.Abstraction;
using ProjetoTeste.Infra.Repositories.Implementation;

namespace ProjetoTeste.Infra.IoC.RepositoriesExtensions
{
    public static class RepositoryExtension
    {
        public static void AddRegisterRepostory(this IServiceCollection services)
        {
            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
