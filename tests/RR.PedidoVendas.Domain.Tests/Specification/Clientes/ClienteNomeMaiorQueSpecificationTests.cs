using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Specification.Clientes;

namespace RR.PedidoVendas.Domain.Tests.Specification.Clientes
{
    [TestClass]
    public class ClienteNomeMaiorQueSpecificationTests
    {
        [TestMethod]
        public void Cliente_NomeMaiorQueSpecification_18_Valido()
        {
            var cliente = new Cliente { Nome = "João José de Souza" };

            var specification = new ClienteNomeMaiorQueValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsTrue(specification);
        }

        [TestMethod]
        public void Cliente_NomeMaiorQueSpecification_2_NaoValido()
        {
            var cliente = new Cliente { Nome = "Jo" };

            var specification = new ClienteNomeMaiorQueValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsFalse(specification);
        }

        [TestMethod]
        public void Cliente_NomeMaiorQueSpecification_Nulo_NaoValido()
        {
            var cliente = new Cliente { Nome = null };

            var specification = new ClienteNomeMaiorQueValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsFalse(specification);
        }

        [TestMethod]
        public void Cliente_NomeMaiorQueSpecification_StringEmpty_NaoValido()
        {
            var cliente = new Cliente { Nome = string.Empty };

            var specification = new ClienteNomeMaiorQueValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsFalse(specification);
        }
    }
}
