using DomainValidation.Interfaces.Specification;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Validation.Bases;

namespace RR.PedidoVendas.Domain.Specification.Itens
{
    public class ItemQuantidadeMaiorQueValidoSpecification : ISpecification<Item>
    {
        public bool IsSatisfiedBy(Item item)
        {
            return QuantidadeMaiorQueValidation.Validar(item.Quantidade, 0);
        }
    }
}
