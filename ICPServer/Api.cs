using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WindowsInput.Events;

namespace ICPServer
{
    public class Startup
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

    public class MainController
    {
        [HttpPost]
        [Route("/action")]
        public void Post([FromBody] Payload payload)
        {
            var value = Convert.ToInt32(payload.Key, 16);
            KeyCode key = (KeyCode)value;
            WindowsInput.Simulate.Events().Hold(key).Wait(100).Release(key).Invoke();
        }
    }

    public class Payload
    {
        public required String Key { get; set; }
    }
}
