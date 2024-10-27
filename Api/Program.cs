using Microsoft.AspNetCore.Hosting;
using MinimalAPI;
using mininal_api;

IHostBuilder CreateHostBuilder(string[] args){
    return Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Start>();
    });
}

CreateHostBuilder(args).Build().Run();