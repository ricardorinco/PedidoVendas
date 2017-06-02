using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Specification.Clientes;

namespace RR.PedidoVendas.Domain.Tests.Specification.Clientes
{
    [TestClass]
    public class ClienteNomeSpecificiationTests
    {
        [TestMethod]
        public void Cliente_NomeSpecification_Valido()
        {
            var cliente = new Cliente { Nome = "João José de Souza" };

            var specification = new ClienteNomeValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsTrue(specification);
        }

        [TestMethod]
        public void Cliente_NomeSpecification_NaoValido()
        {
            var cliente = new Cliente { Nome = "Jo" };

            var specification = new ClienteNomeValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsFalse(specification);
        }

        [TestMethod]
        public void Cliente_NomeSpecification_Nulo_NaoValido()
        {
            var cliente = new Cliente { Nome = null };

            var specification = new ClienteNomeValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsFalse(specification);
        }

        [TestMethod]
        public void Cliente_NomeSpecification_StringEmpty_NaoValido()
        {
            var cliente = new Cliente { Nome = string.Empty };

            var specification = new ClienteNomeValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsFalse(specification);
        }
    }
}
