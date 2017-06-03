using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.PedidoVendas.Domain.Models;
using System.Linq;

namespace RR.PedidoVendas.Domain.Tests.Validation.Produtos
{
    [TestClass]
    public class ProdutoValidationTests
    {
        [TestMethod]
        public void Produto_AutoValidacao_Valido()
        {
            var produto = new Produto
            {
                Id = 1252,
                Descricao = "UNCHARTED: The Lost Legacy - PS4",
                Valor = 179.90m
            };

            Assert.IsTrue(produto.IsValid());
        }

        [TestMethod]
        public void Produto_AutoValidacao_NaoValido()
        {
            var produto = new Produto
            {
                Id = 0,
                Descricao = "PS",
                Valor = -9.90m
            };

            Assert.IsFalse(produto.IsValid());
            Assert.IsTrue(produto.ValidationResult.Erros.Any(p => p.Message == "A descrição do produto deve conter no mínimo 3 caracteres."));
            Assert.IsTrue(produto.ValidationResult.Erros.Any(p => p.Message == "O valor do produto deve ser maior que R$ 0.00."));
            Assert.IsFalse(produto.ValidationResult.Erros.Any(p => p.Message == "O valor do produto deve ser menor que R$ 999.99."));
        }
    }
}
