using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RR.PedidoVendas.Application.ViewModels
{
    public class ItemViewModel : EntidadeBaseViewModel
    {
        [Required(ErrorMessage = "Preencha o campo quantidade.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###.##}")]
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
