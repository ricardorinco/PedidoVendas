using DomainValidation.Validation;
using RR.PedidoVendas.Domain.Interfaces.Repository;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Specification.Itens;

namespace RR.PedidoVendas.Domain.Validation.Itens
{
    public class ItemAptoParaAdicionarValidation : Validator<Item>
    {
        public ItemAptoParaAdicionarValidation(IItemRepository itemRepository)
        {
            var itemProdutoDeveSerUnico = new ItemProdutoDeveSerUnicoSpecification(itemRepository);

            Add("itemProdutoDeveSerUnico", new Rule<Item>(itemProdutoDeveSerUnico, "Produto já inserido no pedido."));
        }
    }
}
