using RR.PedidoVendas.Application.ViewModels;
using System.Collections.Generic;

namespace RR.PedidoVendas.Application.Interfaces
{
    public interface IItemAppService : IAppService<ItemViewModel>
    {
        bool SelecionarProdutoPorPedido(int produtoId, int pedidoId);
        IEnumerable<ItemViewModel> SelecionarPorPedidoId(int pedidoId);
    }
}
