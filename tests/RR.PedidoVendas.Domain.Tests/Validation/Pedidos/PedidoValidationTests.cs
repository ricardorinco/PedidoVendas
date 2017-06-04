using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.PedidoVendas.Domain.Models;
using System;
using System.Linq;

namespace RR.PedidoVendas.Domain.Tests.Validation.Pedidos
{
    [TestClass]
    public class PedidoValidationTests
    {
        [TestMethod]
        public void Pedido_AutoValidacao_Valido()
        {
            var pedido = new Pedido
            {
                Id = 1252,
                DataEntrega = DateTime.Now,
                NumeroControle = 2
            };

            Assert.IsTrue(pedido.IsValid());
        }

        [TestMethod]
        public void Pedido_AutoValidacao_NaoValido()
        {
            var pedido = new Pedido
            {
                Id = 1252,
                DataEntrega = DateTime.Now.AddDays(-4),
                NumeroControle = 2
            };

            Assert.IsFalse(pedido.IsValid());
            Assert.IsTrue(pedido.ValidationResult.Erros.Any(p => p.Message == "A data de entrega deve ser maior ou igual a data atual."));
        }
    }
}
