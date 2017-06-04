using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Specification.Itens;

namespace RR.PedidoVendas.Domain.Tests.Specification.Itens
{
    [TestClass]
    public class ItemQuantidadeMaiorQueSpecificationTests
    {
        [TestMethod]
        public void Item_QuantidadeMaiorQue_0_Valido()
        {
            var item = new Item { Quantidade = 4 };

            var especificacao = new ItemQuantidadeMaiorQueValidoSpecification().IsSatisfiedBy(item);

            Assert.IsTrue(especificacao);
        }

        [TestMethod]
        public void Item_QuantidadeMaiorQue_0_NaoValido()
        {
            var item = new Item { Quantidade = -5 };

            var especificacao = new ItemQuantidadeMaiorQueValidoSpecification().IsSatisfiedBy(item);

            Assert.IsFalse(especificacao);
        }
    }
}
