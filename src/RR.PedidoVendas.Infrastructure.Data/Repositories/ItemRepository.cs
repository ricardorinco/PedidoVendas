using RR.PedidoVendas.Domain.Interfaces.Repository;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace RR.PedidoVendas.Infrastructure.Data.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(DataContext context) : base(context)
        { }

        public bool SelecionarProdutoPorPedido(int produtoId, int pedidoId)
        {
            return Context.Itens.Any(i => i.ProdutoId == produtoId && i.PedidoId == pedidoId);
        }
        public IEnumerable<Item> SelecionarPorPedidoId(int pedidoId)
        {
            return Context.Itens.Where(i => i.PedidoId == pedidoId).ToList();
        }
    }
}
