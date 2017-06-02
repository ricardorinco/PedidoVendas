using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR.PedidoVendas.Application.ViewModels
{
    public class ItemViewModel : EntidadeBaseViewModel
    {
        [Required(ErrorMessage = "Preencha o campo quantidade.")]
        [DisplayName("Quantidade")]
        public decimal Quantidade { get; set; }

        [DisplayName("Produto")]
        public int ProdutoId { get; set; }
        public virtual ProdutoViewModel Produto { get; set; }

        [DisplayName("Pedido")]
        public int PedidoId { get; set; }
        public virtual PedidoViewModel Pedido { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
