using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RR.PedidoVendas.Application.ViewModels
{
    public class PedidoViewModel : EntidadeBaseViewModel
    {
        public PedidoViewModel()
        {
            Itens = new List<ItemViewModel>();
        }

        [Required(ErrorMessage = "Preencha o campo data de entrega.")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Data de Entrega")]
        public DateTime DataEntrega { get; set; }

        [DisplayName("Número de Controle")]
        public int NumeroControle { get; set; }

        [DisplayName("Cliente")]
        public int? ClienteId { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }

        public virtual ICollection<ItemViewModel> Itens { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
