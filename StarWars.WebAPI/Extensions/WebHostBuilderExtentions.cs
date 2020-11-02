using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace StarWars.WebAPI.Extensions
{
    public static class WebHostBuilderExtentions
    {

        public static IWebHostBuilder UseAppSettings(this IWebHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureAppConfiguration((context, builder) =>
            {
                builder.AddJsonFile($"./appsettings.json", false, true);

                if (!context.HostingEnvironment.IsDevelopment())
                {
                    builder.AddJsonFile($"./appsettings.Release.json", true, true);
                }
            });

            return hostBuilder;
        }
    }
}
