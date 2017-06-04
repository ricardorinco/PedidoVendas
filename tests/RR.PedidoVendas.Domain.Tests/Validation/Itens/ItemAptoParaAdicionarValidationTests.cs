using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using RR.PedidoVendas.Domain.Interfaces.Repository;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Validation.Itens;
using System.Linq;

namespace RR.PedidoVendas.Domain.Tests.Validation.Itens
{
    [TestClass]
    public class ItemAptoParaAdicionarValidationTests
    {
        [TestMethod]
        public void Item_AptoParaAdicioanr_Valido()
        {
            var item = new Item { ProdutoId = 2, PedidoId = 68 };

            var repositorio = MockRepository.GenerateStub<IItemRepository>();
            repositorio.Stub(i => i.SelecionarProdutoPorPedido(item.ProdutoId, item.PedidoId)).Return(false);

            var validacao = new ItemAptoParaAdicionarValidation(repositorio).Validate(item);

            Assert.IsTrue(validacao.IsValid);
        }

        [TestMethod]
        public void Item_AptoParaAdicioanr_NaoValido()
        {
            var item = new Item { ProdutoId = 2, PedidoId = 68 };

            var repositorio = MockRepository.GenerateStub<IItemRepository>();
            repositorio.Stub(i => i.SelecionarProdutoPorPedido(item.ProdutoId, item.PedidoId)).Return(true);

            var validacao = new ItemAptoParaAdicionarValidation(repositorio).Validate(item);

            Assert.IsFalse(validacao.IsValid);
            Assert.IsTrue(validacao.Erros.Any(i => i.Message == "Produto já inserido no pedido."));
        }
    }
}
