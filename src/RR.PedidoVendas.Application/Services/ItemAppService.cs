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
    public class ItemAppService : IItemAppService
    {
        private readonly IItemService itemService;
        private readonly IUnitOfWork unitOfWork;

        public ItemAppService(IItemService itemService, IUnitOfWork unitOfWork)
        {
            this.itemService = itemService;
            this.unitOfWork = unitOfWork;
        }

        public ItemViewModel Adicionar(ItemViewModel itemViewModel)
        {
            var item = Mapper.Map<Item>(itemViewModel);
            var itemRetornado = itemService.Adicionar(item);

            if (itemRetornado.ValidationResult.IsValid)
                unitOfWork.Commit();

            itemViewModel = Mapper.Map<ItemViewModel>(itemRetornado);

            return itemViewModel;
        }
        public ItemViewModel Atualizar(ItemViewModel itemViewModel)
        {
            var item = Mapper.Map<Item>(itemViewModel);
            var itemRetornado = itemService.Atualizar(item);

            if (itemRetornado.ValidationResult.IsValid)
                unitOfWork.Commit();

            itemViewModel = Mapper.Map<ItemViewModel>(itemRetornado);

            return itemViewModel;
        }
        public void Remover(int id)
        {
            itemService.Remover(id);
            unitOfWork.Commit();
        }

        public ItemViewModel SelecionarPorId(int id)
        {
            return Mapper.Map<ItemViewModel>(itemService.SelecionarPorId(id));
        }
        public IEnumerable<ItemViewModel> SelecionarTodos()
        {
            return Mapper.Map<IEnumerable<ItemViewModel>>(itemService.SelecionarTodos());
        }

        public void Dispose()
        {
            itemService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
