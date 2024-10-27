using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Infraestrutura.DB;

using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using mininal_api;
using Microsoft.AspNetCore.Hosting;
using MinimalAPI.Dominio.Interfaces;
using test.Mocks;
using Microsoft.Extensions.DependencyInjection;

namespace test.Helpers
{
    public class Setup
        {
        public const string PORT = "5001";
        public static TestContext testContext = default!;
        public static WebApplicationFactory<Start> http = default!;
        public static HttpClient client = default!;

        public static void ClassInit(TestContext testContext)
        {
            Setup.testContext = testContext;
            Setup.http = new WebApplicationFactory<Start>();

            Setup.http = Setup.http.WithWebHostBuilder(builder =>
            {
                builder.UseSetting("https_port", Setup.PORT).UseEnvironment("Testing");
                
                builder.ConfigureServices(services =>
                {
                    services.AddScoped<IAdministradorServico, AdministradorServicoMock>();
                });

            });

            Setup.client = Setup.http.CreateClient();
        }

        public static void ClassCleanup()
        {
            Setup.http.Dispose();
        }
    }
}