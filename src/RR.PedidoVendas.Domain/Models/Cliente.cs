using DomainValidation.Validation;
using RR.PedidoVendas.Domain.Validation.Clientes;
using System.Collections.Generic;

namespace RR.PedidoVendas.Domain.Models
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new ClienteConsistenteValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
