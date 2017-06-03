using DomainValidation.Interfaces.Specification;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Validation.Bases;

namespace RR.PedidoVendas.Domain.Specification.Produtos
{
    public class ProdutoValorMenorQueValidoSpecification : ISpecification<Produto>
    {
        public bool IsSatisfiedBy(Produto produto)
        {
            return ValorMenorQueValidation.Validar(produto.Valor, 999.99m);
        }
    }
}