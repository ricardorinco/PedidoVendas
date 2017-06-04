using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.PedidoVendas.Domain.Models;
using System.Linq;

namespace RR.PedidoVendas.Domain.Tests.Validation.Itens
{
    [TestClass]
    public class ItemValidationTests
    {
        [TestMethod]
        public void Item_AutoValidacao_Valido()
        {
            var item = new Item
            {
                Id = 1,
                Quantidade = 85.8m,
                ProdutoId = 2,
                PedidoId = 68
            };

            Assert.IsTrue(item.IsValid());
        }

        [TestMethod]
        public void Item_AutoValidacao_QuantidadeMenor_NaValido()
        {
            var item = new Item
            {
                Id = 1,
                Quantidade = 0m,
                ProdutoId = 2,
                PedidoId = 68
            };

            Assert.IsFalse(item.IsValid());
            Assert.IsTrue(item.ValidationResult.Erros.Any(i => i.Message == "A quantidade do produto deve ser maior que 0."));
            Assert.IsFalse(item.ValidationResult.Erros.Any(i => i.Message == "A quantidade do produto deve ser menor que 999.99."));
        }

        [TestMethod]
        public void Item_AutoValidacao_QuantidadeMaior_NaValido()
        {
            var item = new Item
            {
                Id = 1,
                Quantidade = 9128.50m,
                ProdutoId = 2,
                PedidoId = 68
            };

            Assert.IsFalse(item.IsValid());
            Assert.IsFalse(item.ValidationResult.Erros.Any(i => i.Message == "A quantidade do produto deve ser maior que 0."));
            Assert.IsTrue(item.ValidationResult.Erros.Any(i => i.Message == "A quantidade do produto deve ser menor que 999.99."));
        }
    }
}
