using Microsoft.Extensions.DependencyInjection;
using VolvoCaminhoes.Domain.Interfaces.Manager;
using VolvoCaminhoes.Domain.Interfaces.Repository;
using VolvoCaminhoes.Manager;
using VolvoCaminhoes.Repository.Repositories;

namespace VolvoCaminhoes.Ioc.Configuration
{
    public static class ConfigureDependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICaminhaoRepository, CaminhaoRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<ICaminhoesManager, CaminhoesManager>();
        }
    }
}
