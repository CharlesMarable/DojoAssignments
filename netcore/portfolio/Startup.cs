using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
 
namespace Portfolio
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseMvc();
            app.UseStaticFiles();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Mvc as a service making it available across our entire app
            services.AddMvc();
        }
    }
}