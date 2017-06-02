using DomainValidation.Interfaces.Specification;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Validation.Bases;

namespace RR.PedidoVendas.Domain.Specification.Produtos
{
    public class ProdutoDescricaoMaiorQueValidaSpecification : ISpecification<Produto>
    {
        public bool IsSatisfiedBy(Produto produto)
        {
            return TextoMaiorQueValidation.Validar(produto.Descricao, 2);
        }
    }
}