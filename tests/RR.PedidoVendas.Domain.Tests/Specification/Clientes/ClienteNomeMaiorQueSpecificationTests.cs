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

            var especificacao = new ClienteNomeMaiorQueValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsTrue(especificacao);
        }

        [TestMethod]
        public void Cliente_NomeMaiorQueSpecification_2_NaoValido()
        {
            var cliente = new Cliente { Nome = "Jo" };

            var especificacao = new ClienteNomeMaiorQueValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsFalse(especificacao);
        }

        [TestMethod]
        public void Cliente_NomeMaiorQueSpecification_Nulo_NaoValido()
        {
            var cliente = new Cliente { Nome = null };

            var especificacao = new ClienteNomeMaiorQueValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsFalse(especificacao);
        }

        [TestMethod]
        public void Cliente_NomeMaiorQueSpecification_StringEmpty_NaoValido()
        {
            var cliente = new Cliente { Nome = string.Empty };

            var especificacao = new ClienteNomeMaiorQueValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsFalse(especificacao);
        }
    }
}
