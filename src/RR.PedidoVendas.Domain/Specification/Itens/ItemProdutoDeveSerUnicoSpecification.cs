using DomainValidation.Interfaces.Specification;
using RR.PedidoVendas.Domain.Interfaces.Repository;
using RR.PedidoVendas.Domain.Models;

namespace RR.PedidoVendas.Domain.Specification.Itens
{
    public class ItemProdutoDeveSerUnicoSpecification : ISpecification<Item>
    {
        private readonly IItemRepository itemRepository;

        public ItemProdutoDeveSerUnicoSpecification(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public bool IsSatisfiedBy(Item item)
        {
            return !itemRepository.SelecionarProdutoPorPedido(item.ProdutoId, item.PedidoId);
        }
    }
}
