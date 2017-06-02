using DomainValidation.Validation;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Specification.Produtos;

namespace RR.PedidoVendas.Domain.Validation.Produtos
{
    public class ProdutoConsistenteValidation : Validator<Produto>
    {
        public ProdutoConsistenteValidation()
        {
            var produtoDescricaoValida = new ProdutoDescricaoValidaSpecification();
            var produtoValorValido = new ProdutoValorValidoSpecification();

            Add("produtoDescricaoValida", new Rule<Produto>(produtoDescricaoValida, "A descrição do produto deve conter no mínimo 3 caracteres."));
            Add("produtoValorValido", new Rule<Produto>(produtoValorValido, "O valor do produto não deve ser negativo."));
        }
    }
}
