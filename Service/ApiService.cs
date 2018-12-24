using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;

namespace WebApi
{
    public class ApiService
    {
        public static ApiService Factory = new Lazy<ApiService>(() => new ApiService()).Value;
        private IDisposable webservice { get; set; }
        private StartOptions options { get; set; }
        private ApiService()
        {
            options = new StartOptions();
            options.Urls.Add("http://+:9000");
            options.Urls.Add("http://+:9001");
        }

        public void Start()
        {
            Stop();
            webservice = WebApp.Start(options, (p) =>
            {
                Console.WriteLine("Sample Middleware loaded...");
                p.UseApiIndexPage();
                p.Use<ApiMiddleware>();

            });
        }

        public void Stop()
        {
            webservice?.Dispose();
        }

    }
}
