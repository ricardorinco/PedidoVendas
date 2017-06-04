using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Specification.Clientes;

namespace RR.PedidoVendas.Domain.Tests.Specification.Clientes
{
    [TestClass]
    public class ClienteCPFSpecificationTests
    {
        [TestMethod]
        public void Cliente_CPFSpecification_11_Formatado_Valido()
        {
            var cliente = new Cliente { CPF = "243.364.567-04" };

            var especificacao = new ClienteCPFValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsTrue(especificacao);
        }

        [TestMethod]
        public void Cliente_CPFSpecification_11_Valido()
        {
            var cliente = new Cliente { CPF = "30695598325" };

            var especificacao = new ClienteCPFValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsTrue(especificacao);
        }

        [TestMethod]
        public void Cliente_CPFSpecification_11_Formatado_NaoValido()
        {
            var cliente = new Cliente { CPF = "125.364.567-04" };

            var especificacao = new ClienteCPFValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsFalse(especificacao);
        }

        [TestMethod]
        public void Cliente_CPFSpecification_11_NaoValido()
        {
            var cliente = new Cliente { CPF = "25632578950" };

            var especificacao = new ClienteCPFValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsFalse(especificacao);
        }

        [TestMethod]
        public void Cliente_CPFSpecification_8_Formatado_NaoValido()
        {
            var cliente = new Cliente { CPF = "125.845.85" };

            var especificacao = new ClienteCPFValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsFalse(especificacao);
        }

        [TestMethod]
        public void Cliente_CPFSpecification_11_Formatado_Letra_NaoValido()
        {
            var cliente = new Cliente { CPF = "XCV.ASD.ADS-DV" };

            var especificacao = new ClienteCPFValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsFalse(especificacao);
        }

        [TestMethod]
        public void Cliente_CPFSpecification_Nulo_NaoValido()
        {
            var cliente = new Cliente { CPF = null };

            var especificacao = new ClienteCPFValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsFalse(especificacao);
        }

        [TestMethod]
        public void Cliente_CPFSpecification_StringEmpty_NaoValido()
        {
            var cliente = new Cliente { CPF = string.Empty };

            var especificacao = new ClienteCPFValidoSpecification().IsSatisfiedBy(cliente);

            Assert.IsFalse(especificacao);
        }
    }
}
