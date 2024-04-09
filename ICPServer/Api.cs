using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Sockets;
using System.Net;
using WindowsInput.Events;
using Microsoft.AspNetCore.Hosting;

namespace ICPServer
{
    public class Config
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

    public class Server
    {
        public static string GetLocalIp()
        {
            var hosts = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in hosts.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    if (ip.ToString().Contains("192."))
                    {
                        return ip.ToString();
                    };
                }
            }
            return null;
        }

        public static IHost HostBuilder(string Port)
        {
            return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webHostBuilder =>
            {
                webHostBuilder.UseUrls($"http://*:{Port}");
                webHostBuilder.UseStartup<Config>();
            }).Build();
        }
    }

    public class MainController
    {

        [HttpPost]
        [Route("/action")]
        public void Post([FromBody] Payload payload)
        {
            try
            {
                var value = Convert.ToInt32(payload.Key, 16);
                KeyCode key = (KeyCode)value;
                WindowsInput.Simulate.Events().Hold(key).Wait(100).Release(key).Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class Payload
    {
        public string Key { get; set; }
    }
}
