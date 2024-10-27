using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalAPI.Dominio.Entidades;
using MinimalAPI.Dominio.Servicos;
using MinimalAPI.Infraestrutura.DB;


namespace test.Domain.Servicos
{
    [TestClass]
    public class AdministradorServicoTest
    {

        
        private DBContexto CriarContextoDeTest()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

            // Configurar o ConfigurationBuilder
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DBContexto(configuration);
        }

        [TestMethod]
        public void TestandoSalvarAdministrador()
        {
            // Arrange
            var context = CriarContextoDeTest();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

            var adm = new Administrador();
            adm.Email = "test@test.com";
            adm.Senha = "test";
            adm.Perfil = "Adm";

            var administradorServico = new AdministradorServico(context);

            // Act  
            administradorServico.Incluir(adm);
            var adm1 = administradorServico.BuscarPorId(adm.Id);

            // Assert
            Assert.AreEqual(1, administradorServico.Todos(1).Count());
        
        }

        [TestMethod]
        public void TestandoBuscarPorId()
        {
            // Arrange
            var context = CriarContextoDeTest();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

            var adm = new Administrador();
            adm.Email = "test@test.com";
            adm.Senha = "test";
            adm.Perfil = "Adm";

            var administradorServico = new AdministradorServico(context);

            // Act  
            administradorServico.Incluir(adm);
            var admDoBanco = administradorServico.BuscarPorId(adm.Id);

            // Assert
            Assert.AreEqual(1, admDoBanco!.Id);
        
        }
    }
}