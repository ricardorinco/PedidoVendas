using RR.PedidoVendas.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace RR.PedidoVendas.Application.Interfaces
{
    public interface IPedidoAppService : IAppService<PedidoViewModel>
    {
        IEnumerable<PedidoViewModel> SelecionarPorNumeroControle(int numeroControle);
        IEnumerable<PedidoViewModel> SelecionarPorClienteId(int clienteId);
        IEnumerable<PedidoViewModel> SelecionarPorDataEntrega(DateTime dataEntregaInicial, DateTime dataEntregaFinal);
    }
}
