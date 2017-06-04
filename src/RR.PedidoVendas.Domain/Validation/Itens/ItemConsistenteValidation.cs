using DomainValidation.Validation;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Specification.Itens;

namespace RR.PedidoVendas.Domain.Validation.Itens
{
    public class ItemConsistenteValidation : Validator<Item>
    {
        public ItemConsistenteValidation()
        {
            var itemQuantidadeMaiorQueValido = new ItemQuantidadeMaiorQueValidoSpecification();
            var itemQuantidadeMenorQueValido = new ItemQuantidadeMenorQueValidoSpecification();

            Add("itemQuantidadeMaiorQueValido", new Rule<Item>(itemQuantidadeMaiorQueValido, "A quantidade do produto deve ser maior que 0."));
            Add("itemQuantidadeMenorQueValido", new Rule<Item>(itemQuantidadeMenorQueValido, "A quantidade do produto deve ser menor que 999.99."));
        }
    }
}
