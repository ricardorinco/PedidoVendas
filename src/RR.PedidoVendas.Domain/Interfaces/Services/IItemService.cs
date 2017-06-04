using RR.PedidoVendas.Domain.Models;
using System.Collections.Generic;

namespace RR.PedidoVendas.Domain.Interfaces.Services
{
    public interface IItemService : IService<Item>
    {
        bool SelecionarProdutoPorPedido(int produtoId, int pedidoId);
        IEnumerable<Item> SelecionarPorPedidoId(int pedidoId);
    }
}
