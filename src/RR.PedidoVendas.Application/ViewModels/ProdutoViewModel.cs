using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RR.PedidoVendas.Application.ViewModels
{
    public class ProdutoViewModel : EntidadeBaseViewModel
    {
        public ProdutoViewModel()
        {
            Itens = new List<ItemViewModel>();
        }

        [Required(ErrorMessage = "Preencha o campo descrição")]
        [MaxLength(180, ErrorMessage = "Máximo de {0} caracteres permitidos")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres permitidos")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo valor")]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        public virtual ICollection<ItemViewModel> Itens { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
