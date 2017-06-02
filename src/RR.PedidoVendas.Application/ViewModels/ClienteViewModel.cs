using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RR.PedidoVendas.Application.ViewModels
{
    public class ClienteViewModel : EntidadeBaseViewModel
    {
        public ClienteViewModel()
        {
            Pedidos = new List<PedidoViewModel>();
        }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(180, ErrorMessage = "Máximo de {0} caracteres permitidos")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres permitidos")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo cpf")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
