using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace VolvoCaminhoes.Repository.Database
{
    [ExcludeFromCodeCoverage]
    public class DatabaseConnection
    {
        public static IConfiguration Configuration
        {
            get
            {
                IConfigurationRoot Configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                return Configuration;
            }
        }
    }
}
