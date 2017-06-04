using RR.PedidoVendas.Domain.Interfaces.Repository;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
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
            var proximoNumeroControle = Context.Pedidos
                .Select(p => p.NumeroControle)
                .OrderByDescending(p => p)
                .FirstOrDefault();

            return proximoNumeroControle + 1;
        }
        public IEnumerable<Pedido> SelecionarPorNumeroControle(int numeroControle)
        {
            return Context.Pedidos.Where(p => p.NumeroControle == numeroControle).ToList();
        }
        public IEnumerable<Pedido> SelecionarPorClienteId(int clienteId)
        {
            if (clienteId == 0)
                return Context.Pedidos.Where(p => p.ClienteId == null).ToList();

            return Context.Pedidos.Where(p => p.ClienteId == clienteId).ToList();
        }
        public IEnumerable<Pedido> SelecionarPorDataEntrega(DateTime dataEntregaInicial, DateTime dataEntregaFinal)
        {
            return Context.Pedidos.Where(p => p.DataEntrega >= dataEntregaInicial && p.DataEntrega <= dataEntregaFinal).ToList();
        }
    }
}
