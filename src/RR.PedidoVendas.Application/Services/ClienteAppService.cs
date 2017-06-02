using AutoMapper;
using RR.PedidoVendas.Application.Interfaces;
using RR.PedidoVendas.Application.ViewModels;
using RR.PedidoVendas.Domain.Interfaces.Services;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace RR.PedidoVendas.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService clienteService;
        private readonly IUnitOfWork unitOfWork;

        public ClienteAppService(IClienteService clienteService, IUnitOfWork unitOfWork)
        {
            this.clienteService = clienteService;
            this.unitOfWork = unitOfWork;
        }

        public ClienteViewModel Adicionar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            var clienteRetornado = clienteService.Adicionar(cliente);

            if (clienteRetornado.ValidationResult.IsValid)
                unitOfWork.Commit();

            clienteViewModel = Mapper.Map<ClienteViewModel>(clienteRetornado);

            return clienteViewModel;
        }
        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            var clienteRetornado = clienteService.Atualizar(cliente);

            if (clienteRetornado.ValidationResult.IsValid)
                unitOfWork.Commit();

            clienteViewModel = Mapper.Map<ClienteViewModel>(clienteRetornado);

            return clienteViewModel;
        }
        public void Remover(int id)
        {
            clienteService.Remover(id);
            unitOfWork.Commit();
        }

        public ClienteViewModel SelecionarPorId(int id)
        {
            return Mapper.Map<ClienteViewModel>(clienteService.SelecionarPorId(id));
        }
        public IEnumerable<ClienteViewModel> SelecionarTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(clienteService.SelecionarTodos());
        }

        public void Dispose()
        {
            clienteService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
