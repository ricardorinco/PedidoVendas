using RR.PedidoVendas.Domain.Interfaces.Repository;
using RR.PedidoVendas.Domain.Interfaces.Services;
using RR.PedidoVendas.Domain.Models;
using System.Collections.Generic;

namespace RR.PedidoVendas.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            if (!cliente.IsValid())
                return cliente;

            if (!cliente.ValidationResult.IsValid)
                return cliente;

            return clienteRepository.Adicionar(cliente);
        }
        public Cliente Atualizar(Cliente cliente)
        {
            if (!cliente.IsValid())
                return cliente;

            return clienteRepository.Atualizar(cliente);
        }
        public void Remover(int id)
        {
            clienteRepository.Remover(id);
        }

        public Cliente SelecionarPorId(int id)
        {
            return clienteRepository.SelecionarPorId(id);
        }
        public IEnumerable<Cliente> SelecionarTodos()
        {
            return clienteRepository.SelecionarTodos();
        }

        public void Dispose()
        {
            clienteRepository.Dispose();
        }
    }
}
