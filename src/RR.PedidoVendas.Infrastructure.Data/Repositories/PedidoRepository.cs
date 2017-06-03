using RR.PedidoVendas.Domain.Interfaces.Repository;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Infrastructure.Data.Context;
using System.Data.Entity;
using System.Linq;

namespace RR.PedidoVendas.Infrastructure.Data.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(DataContext context) : base(context)
        { }

        public override Pedido Atualizar(Pedido pedido)
        {
            var pedidoAtualizar = Context.Entry(pedido);
            DbSet.Attach(pedido);
            pedidoAtualizar.State = EntityState.Modified;
            pedidoAtualizar.Property("NumeroControle").IsModified = false;

            return pedido;
        }

        public int ProximoNumeroControle()
        {
            var proximo = Context.Pedidos
                .Select(p => new
                {
                    NumeroControle = p.NumeroControle
                })
                .OrderByDescending(p => p.NumeroControle)
                .FirstOrDefault();

            return proximo.NumeroControle + 1;
        }
    }
}
