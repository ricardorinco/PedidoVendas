using DomainValidation.Interfaces.Specification;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Validation.Bases;

namespace RR.PedidoVendas.Domain.Specification.Produtos
{
    public class ProdutoValorMaiorQueValidoSpecification : ISpecification<Produto>
    {
        public bool IsSatisfiedBy(Produto produto)
        {
            return ValorMaiorQueValidation.Validar(produto.Valor, 0.00m);
        }
    }
}
