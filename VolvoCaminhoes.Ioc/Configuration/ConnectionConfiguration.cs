using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using VolvoCaminhoes.Repository.Database.Context;

namespace VolvoCaminhoes.Ioc.Configuration
{
    public static class ConnectionConfiguration
    {
        public static void AddDataBase(this IServiceCollection services)
        {
            var iConfig = GetConfigurationRoot();
            var connectionString = iConfig.GetSection("ConnectionStrings")["DefaultConnection"];
            services.AddDbContext<VolvoCaminhoesContext>(options => options
                                                                            .UseLazyLoadingProxies()
                                                                            .UseSqlServer(connectionString));
        }
        private static IConfigurationRoot GetConfigurationRoot()
        {
            var projectDir = Directory.GetCurrentDirectory();

            return new ConfigurationBuilder()
                .SetBasePath(projectDir)
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
