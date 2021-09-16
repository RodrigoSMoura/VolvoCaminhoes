using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using VolvoCaminhoes.Repository.Database.Context;

namespace VolvoCaminhoes.Tests.Repository.Helper
{
    [ExcludeFromCodeCoverage]
    public class RepositoryTestsBase
    {
        protected readonly VolvoCaminhoesContext context;

        public RepositoryTestsBase()
        {
            var iConfig = GetConfigurationRoot();
            var connectionString = iConfig.GetSection("ConnectionStrings")["DefaultConnection"];

            var options = new DbContextOptionsBuilder<VolvoCaminhoesContext>()
                .UseSqlServer(connectionString)
                .Options;

            context = new VolvoCaminhoesContext(options);
        }

        private static IConfigurationRoot GetConfigurationRoot()
        {
            var projectDir = Directory.GetCurrentDirectory();

            return new ConfigurationBuilder()
                .SetBasePath(projectDir)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public VolvoCaminhoesContext GetContext()
        {
            return context;
        }
    }
}
