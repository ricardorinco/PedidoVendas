using DomainValidation.Interfaces.Specification;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Validation.Bases;

namespace RR.PedidoVendas.Domain.Specification.Itens
{
    public class ItemQuantidadeMenorQueValidoSpecification : ISpecification<Item>
    {
        public bool IsSatisfiedBy(Item item)
        {
            return QuantidadeMenorQueValidation.Validar(item.Quantidade, 1000m);
        }
    }
}
