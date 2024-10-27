using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalAPI.Dominio.Entidades;

namespace test.Domain.Entidades
{
    [TestClass]
    public class VeiculoTest
    {
        [TestMethod]
        public void TestarGetSetProp()
        {
            // Arrange
            var veiculo = new Veiculo();

            // Act
            veiculo.Id = 1;
            veiculo.Nome = "testNome";
            veiculo.Marca = "testMarca";
            veiculo.Ano = 2024;


            // Assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("testNome", veiculo.Nome);
            Assert.AreEqual("testMarca", veiculo.Marca);
            Assert.AreEqual(2024, veiculo.Ano);
        }       
    }
}