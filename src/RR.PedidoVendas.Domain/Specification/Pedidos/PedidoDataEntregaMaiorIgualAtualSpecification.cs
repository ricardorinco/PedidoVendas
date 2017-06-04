using DomainValidation.Interfaces.Specification;
using RR.PedidoVendas.Domain.Models;
using System;

namespace RR.PedidoVendas.Domain.Specification.Pedidos
{
    public class PedidoDataEntregaMaiorIgualAtualSpecification : ISpecification<Pedido>
    {
        public bool IsSatisfiedBy(Pedido pedido)
        {
            return pedido.DataEntrega.Date >= DateTime.Now.Date;
        }
    }
}
