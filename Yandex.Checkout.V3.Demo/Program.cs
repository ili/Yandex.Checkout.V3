﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Yandex.Checkout.V3.Demo
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
