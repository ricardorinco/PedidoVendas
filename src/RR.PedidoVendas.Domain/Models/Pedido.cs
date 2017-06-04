using DomainValidation.Validation;
using RR.PedidoVendas.Domain.Validation.Pedidos;
using System;
using System.Collections.Generic;

namespace RR.PedidoVendas.Domain.Models
{
    public class Pedido : EntidadeBase
    {
        public DateTime DataEntrega { get; set; }
        public int NumeroControle { get; set; }

        public int? ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<Item> Itens { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new PedidoConsistenteValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
