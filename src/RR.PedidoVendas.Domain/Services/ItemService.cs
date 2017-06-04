using RR.PedidoVendas.Domain.Interfaces.Repository;
using RR.PedidoVendas.Domain.Interfaces.Services;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Validation.Itens;
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

            item.ValidationResult = new ItemAptoParaAdicionarValidation(itemRepository).Validate(item);

            if (!item.ValidationResult.IsValid)
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
        public bool SelecionarProdutoPorPedido(int produtoId, int pedidoId)
        {
            return itemRepository.SelecionarProdutoPorPedido(produtoId, pedidoId);
        }
        public IEnumerable<Item> SelecionarTodos()
        {
            return itemRepository.SelecionarTodos();
        }
        public IEnumerable<Item> SelecionarPorPedidoId(int pedidoId)
        {
            return itemRepository.SelecionarPorPedidoId(pedidoId);
        }

        public void Dispose()
        {
            itemRepository.Dispose();
        }
    }
}
