using Microsoft.Extensions.Hosting;
using System.Net.Sockets;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ICPServer.Data
{
    public class Server
    {
        public static IHost HostBuilder(string Port)
        {
            return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webHostBuilder =>
            {
                webHostBuilder.UseUrls($"http://*:{Port}");
                webHostBuilder.UseStartup<ServerConfig>();
            }).Build();
        }

        private class ServerConfig
        {
            public static void ConfigureServices(IServiceCollection services)
            {
                services.AddControllers();
            }

            public static void Configure(IApplicationBuilder app)
            {
                app.UseRouting();

                app.UseEndpoints(routes =>
                {
                    routes.MapControllers();
                });
            }
        }
    }

}
