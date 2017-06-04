using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Specification.Itens;

namespace RR.PedidoVendas.Domain.Tests.Specification.Itens
{
    [TestClass]
    public class ItemQuantidadeMenorQueSpecificationTests
    {
        [TestMethod]
        public void Item_QuantidadeMenorQue_999_Valido()
        {
            var item = new Item { Quantidade = 999.99m };

            var especificacao = new ItemQuantidadeMenorQueValidoSpecification().IsSatisfiedBy(item);

            Assert.IsTrue(especificacao);
        }

        [TestMethod]
        public void Item_QuantidadeMaiorQue_999_NaoValido()
        {
            var item = new Item { Quantidade = 1000 };

            var especificacao = new ItemQuantidadeMenorQueValidoSpecification().IsSatisfiedBy(item);

            Assert.IsFalse(especificacao);
        }
    }
}
