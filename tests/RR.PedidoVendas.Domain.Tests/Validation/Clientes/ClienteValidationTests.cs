using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.PedidoVendas.Domain.Models;
using System.Linq;

namespace RR.PedidoVendas.Domain.Tests.Validation.Clientes
{
    [TestClass]
    public class ClienteValidationTests
    {
        [TestMethod]
        public void Cliente_AutoValidacao_Valido()
        {
            var cliente = new Cliente
            {
                Id = 2568,
                Nome = "Victor Martins",
                CPF = "345.182.042-04"
            };
            
            Assert.IsTrue(cliente.IsValid());
        }

        [TestMethod]
        public void Cliente_AutoValidacao_NaoValido()
        {
            var cliente = new Cliente
            {
                Id = 0,
                Nome = "Vi",
                CPF = "123.182.042-04"
            };

            Assert.IsFalse(cliente.IsValid());
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(c => c.Message == "O nome do cliente deve conter no mínimo 3 caracteres."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(c => c.Message == "Informe um CPF válido."));
        }
    }
}
