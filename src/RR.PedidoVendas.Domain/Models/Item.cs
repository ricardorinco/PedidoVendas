using DomainValidation.Validation;
using RR.PedidoVendas.Domain.Validation.Itens;

namespace RR.PedidoVendas.Domain.Models
{
    public class Item : EntidadeBase
    {
        public decimal Quantidade { get; set; }

        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new ItemConsistenteValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
