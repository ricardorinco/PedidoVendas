using RR.PedidoVendas.Domain.Interfaces.Repository;
using RR.PedidoVendas.Domain.Interfaces.Services;
using RR.PedidoVendas.Domain.Models;
using System;
using System.Collections.Generic;

namespace RR.PedidoVendas.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public Pedido Adicionar(Pedido pedido)
        {
            if (!pedido.IsValid())
                return pedido;

            if (!pedido.ValidationResult.IsValid)
                return pedido;

            return pedidoRepository.Adicionar(pedido);
        }
        public Pedido Atualizar(Pedido pedido)
        {
            if (!pedido.IsValid())
                return pedido;

            return pedidoRepository.Atualizar(pedido);
        }
        public void Remover(int id)
        {
            pedidoRepository.Remover(id);
        }

        public Pedido SelecionarPorId(int id)
        {
            return pedidoRepository.SelecionarPorId(id);
        }
        public IEnumerable<Pedido> SelecionarPorNumeroControle(int numeroControle)
        {
            return pedidoRepository.SelecionarPorNumeroControle(numeroControle);
        }
        public IEnumerable<Pedido> SelecionarTodos()
        {
            return pedidoRepository.SelecionarTodos();
        }
        public IEnumerable<Pedido> SelecionarPorClienteId(int clienteId)
        {
            return pedidoRepository.SelecionarPorClienteId(clienteId);
        }
        public IEnumerable<Pedido> SelecionarPorDataEntrega(DateTime dataEntregaInicial, DateTime dataEntregaFinal)
        {
            return pedidoRepository.SelecionarPorDataEntrega(dataEntregaInicial, dataEntregaFinal);
        }

        public int ProximoNumeroControle()
        {
            return pedidoRepository.ProximoNumeroControle();
        }

        public void Dispose()
        {
            pedidoRepository.Dispose();
        }
    }
}
