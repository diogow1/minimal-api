using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalAPI.Dominio.Entidades;

namespace test.Domain.Entidades
{
    [TestClass]
    public class AdministradorTest
    {
        [TestMethod]
        public void TestarGetSetProp()
        {
            // Arrange
            var adm = new Administrador();

            // Act 
            adm.Id = 1;
            adm.Email = "test@test.com";
            adm.Senha = "test";
            adm.Perfil = "Adm";

            // Assert
            Assert.AreEqual(1, adm.Id);
            Assert.AreEqual("test@test.com", adm.Email);
            Assert.AreEqual("test", adm.Senha);
            Assert.AreEqual("Adm", adm.Perfil);
        }
    }
}