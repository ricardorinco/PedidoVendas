using RR.PedidoVendas.Domain.Models;
using System.Collections.Generic;

namespace RR.PedidoVendas.Domain.Interfaces.Repository
{
    public interface IItemRepository : IRepository<Item>
    {
        bool SelecionarProdutoPorPedido(int produtoId, int pedidoId);
        IEnumerable<Item> SelecionarPorPedidoId(int pedidoId);
    }
}
