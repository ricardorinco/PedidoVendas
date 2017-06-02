using RR.PedidoVendas.Domain.Interfaces.Repository;
using RR.PedidoVendas.Domain.Interfaces.Services;
using RR.PedidoVendas.Domain.Models;
using System.Collections.Generic;

namespace RR.PedidoVendas.Domain.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public Item Adicionar(Item item)
        {
            if (!item.IsValid())
                return item;

            // item.ValidationResult = new ItemConsistenteValidation().Validate(item);

            if (item.ValidationResult.IsValid)
                return item;

            return itemRepository.Adicionar(item);
        }
        public Item Atualizar(Item item)
        {
            if (!item.IsValid())
                return item;

            return itemRepository.Atualizar(item);
        }
        public void Remover(int id)
        {
            itemRepository.Remover(id);
        }

        public Item SelecionarPorId(int id)
        {
            return itemRepository.SelecionarPorId(id);
        }
        public IEnumerable<Item> SelecionarTodos()
        {
            return itemRepository.SelecionarTodos();
        }

        public void Dispose()
        {
            itemRepository.Dispose();
        }
    }
}
