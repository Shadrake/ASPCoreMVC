using Microsoft.Extensions.Configuration;

namespace ASPCoreMVC.DAL
{
    public static class AppSettings
    {
        private static IConfigurationRoot _configuration;

        // Obtiene la cadena de conexión desde appsettings.json
        public static string GetConnectionString()
        {
            if (_configuration == null)
            {
                _configuration = new ConfigurationBuilder()
                    .SetBasePath(System.AppContext.BaseDirectory) // ruta base del proyecto
                    .AddJsonFile("appsettings.json") // lee el archivo
                    .Build();
            }

            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}