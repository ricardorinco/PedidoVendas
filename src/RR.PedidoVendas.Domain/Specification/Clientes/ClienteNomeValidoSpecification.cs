using DomainValidation.Interfaces.Specification;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Validation.Bases;

namespace RR.PedidoVendas.Domain.Specification.Clientes
{
    public class ClienteNomeValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return TextoValidation.Validar(cliente.Nome);
        }
    }
}
