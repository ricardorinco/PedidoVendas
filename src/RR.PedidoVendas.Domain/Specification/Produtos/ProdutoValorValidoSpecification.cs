using DomainValidation.Interfaces.Specification;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Validation.Bases;

namespace RR.PedidoVendas.Domain.Specification.Produtos
{
    public class ProdutoValorValidoSpecification : ISpecification<Produto>
    {
        public bool IsSatisfiedBy(Produto produto)
        {
            return ValorValidation.Validar(produto.Valor);
        }
    }
}
