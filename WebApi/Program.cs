﻿using Microsoft.Extensions.Hosting;
using NLog.Web;
using Microsoft.AspNetCore.Hosting;
using AspectCore.Extensions.DependencyInjection;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
     

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
              
                .UseServiceProviderFactory(new AspectCoreServiceProviderFactory()).UseNLog()
            ;




}
}
