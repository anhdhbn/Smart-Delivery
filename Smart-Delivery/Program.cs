using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MQTTnet.AspNetCore;

namespace SmartDelivery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            int port = 5000, portHttps = 5001, portMqtt = 1883;
            foreach (var arg in args)
            {
                if (arg.Contains("--port"))
                {
                    port = int.Parse(arg.Split('=')[1]);
                }
                if (arg.Contains("--portMqtt"))
                {
                    portMqtt = int.Parse(arg.Split('=')[1]);
                }
                if (arg.Contains("--portHttps"))
                {
                    portHttps = int.Parse(arg.Split('=')[1]);
                }
            }
            Console.WriteLine("Port http: {0}", port);
            Console.WriteLine("Port mqtt: {0}", portMqtt);

            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel(o=> 
                {
                    o.ListenAnyIP(portMqtt, l => l.UseMqtt()); // mqtt pipeline
                    o.ListenAnyIP(port); // default http pipeline
                })
                .UseStartup<Startup>();
        }
            
    }
}
