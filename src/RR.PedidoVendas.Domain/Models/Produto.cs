using DomainValidation.Validation;
using RR.PedidoVendas.Domain.Validation.Produtos;
using System.Collections.Generic;

namespace RR.PedidoVendas.Domain.Models
{
    public class Produto : EntidadeBase
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<Item> Itens { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new ProdutoConsistenteValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
