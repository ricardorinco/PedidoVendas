using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Specification.Pedidos;
using System;

namespace RR.PedidoVendas.Domain.Tests.Specification.Pedidos
{
    [TestClass]
    public class PedidoDataEntregaMaiorIgualAtualSpecificationTests
    {
        [TestMethod]
        public void Pedido_DataEntregaIgualAtual_Valido()
        {
            var pedido = new Pedido { DataEntrega = DateTime.Now };

            var specification = new PedidoDataEntregaMaiorIgualAtualSpecification().IsSatisfiedBy(pedido);

            Assert.IsTrue(specification);
        }

        [TestMethod]
        public void Pedido_DataEntregaMaiorAtual_Valido()
        {
            var pedido = new Pedido { DataEntrega = DateTime.Now.AddDays(2) };

            var specification = new PedidoDataEntregaMaiorIgualAtualSpecification().IsSatisfiedBy(pedido);

            Assert.IsTrue(specification);
        }


        [TestMethod]
        public void Pedido_DataEntregaMenorAtual_NaoValido()
        {
            var pedido = new Pedido { DataEntrega = DateTime.Now.AddDays(-2) };
            
            var specification = new PedidoDataEntregaMaiorIgualAtualSpecification().IsSatisfiedBy(pedido);

            Assert.IsFalse(specification);
        }
    }
}
