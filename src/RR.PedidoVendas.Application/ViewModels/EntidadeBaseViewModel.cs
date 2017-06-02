using System.ComponentModel.DataAnnotations;

namespace RR.PedidoVendas.Application.ViewModels
{
    public abstract class EntidadeBaseViewModel
    {
        [Key]
        public int Id { get; set; }
    }
}
