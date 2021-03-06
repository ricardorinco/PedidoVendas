﻿using AutoMapper;
using RR.PedidoVendas.Application.Interfaces;
using RR.PedidoVendas.Application.ViewModels;
using RR.PedidoVendas.Domain.Interfaces.Services;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace RR.PedidoVendas.Application.Services
{
    public class PedidoAppService : IPedidoAppService
    {
        private readonly IPedidoService pedidoService;
        private readonly IUnitOfWork unitOfWork;

        public PedidoAppService(IPedidoService pedidoService, IUnitOfWork unitOfWork)
        {
            this.pedidoService = pedidoService;
            this.unitOfWork = unitOfWork;
        }

        public PedidoViewModel Adicionar(PedidoViewModel pedidoViewModel)
        {
            pedidoViewModel.NumeroControle = pedidoService.ProximoNumeroControle();
            var pedido = Mapper.Map<Pedido>(pedidoViewModel);
            var pedidoRetornado = pedidoService.Adicionar(pedido);

            if (pedidoRetornado.ValidationResult.IsValid)
                unitOfWork.Commit();

            pedidoViewModel = Mapper.Map<PedidoViewModel>(pedidoRetornado);

            return pedidoViewModel;
        }
        public PedidoViewModel Atualizar(PedidoViewModel pedidoViewModel)
        {
            var pedido = Mapper.Map<Pedido>(pedidoViewModel);
            var pedidoRetornado = pedidoService.Atualizar(pedido);

            if (pedidoRetornado.ValidationResult.IsValid)
                unitOfWork.Commit();

            pedidoViewModel = Mapper.Map<PedidoViewModel>(pedidoRetornado);

            return pedidoViewModel;
        }
        public void Remover(int id)
        {
            pedidoService.Remover(id);
            unitOfWork.Commit();
        }

        public PedidoViewModel SelecionarPorId(int id)
        {
            return Mapper.Map<PedidoViewModel>(pedidoService.SelecionarPorId(id));
        }
        public IEnumerable<PedidoViewModel> SelecionarPorNumeroControle(int numeroControle)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(pedidoService.SelecionarPorNumeroControle(numeroControle));
        }
        public IEnumerable<PedidoViewModel> SelecionarTodos()
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(pedidoService.SelecionarTodos());
        }
        public IEnumerable<PedidoViewModel> SelecionarPorClienteId(int clienteId)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(pedidoService.SelecionarPorClienteId(clienteId));
        }
        public IEnumerable<PedidoViewModel> SelecionarPorDataEntrega(DateTime dataEntregaInicial, DateTime dataEntregaFinal)
        {
            return Mapper.Map<IEnumerable<PedidoViewModel>>(pedidoService.SelecionarPorDataEntrega(dataEntregaInicial, dataEntregaFinal));
        }

        public void Dispose()
        {
            pedidoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
