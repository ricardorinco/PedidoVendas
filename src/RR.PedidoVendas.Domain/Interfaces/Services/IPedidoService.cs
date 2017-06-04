using RR.PedidoVendas.Domain.Models;
using System;
using System.Collections.Generic;

namespace RR.PedidoVendas.Domain.Interfaces.Services
{
    public interface IPedidoService : IService<Pedido>
    {
        int ProximoNumeroControle();

        IEnumerable<Pedido> SelecionarPorNumeroControle(int numeroControle);
        IEnumerable<Pedido> SelecionarPorClienteId(int clienteId);
        IEnumerable<Pedido> SelecionarPorDataEntrega(DateTime dataEntregaInicial, DateTime dataEntregaFinal);
    }
}
