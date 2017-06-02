using DomainValidation.Interfaces.Specification;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Validation.Bases;

namespace RR.PedidoVendas.Domain.Specification.Produtos
{
    public class ProdutoDescricaoValidaSpecification : ISpecification<Produto>
    {
        public bool IsSatisfiedBy(Produto produto)
        {
            return TextoValidation.Validar(produto.Descricao);
        }
    }
}
