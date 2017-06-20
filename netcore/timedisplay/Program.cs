using System.IO;
using Microsoft.AspNetCore.Hosting;
 
namespace YourNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup()
                // New Use method
                .UseIISIntegration()
                .Build();
            host.Run();
        }
    }
}