using DomainValidation.Validation;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Specification.Pedidos;

namespace RR.PedidoVendas.Domain.Validation.Pedidos
{
    public class PedidoConsistenteValidation : Validator<Pedido>
    {
        public PedidoConsistenteValidation()
        {
            var pedidoDataEntregaMaiorIgualAtual = new PedidoDataEntregaMaiorIgualAtualSpecification();

            Add("pedidoDataEntregaMaiorIgualAtual", new Rule<Pedido>(pedidoDataEntregaMaiorIgualAtual, "A data de entrega deve ser maior ou igual a data atual."));
        }
    }
}
