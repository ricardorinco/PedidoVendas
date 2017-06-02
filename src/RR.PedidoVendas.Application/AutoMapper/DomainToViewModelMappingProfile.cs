using AutoMapper;
using RR.PedidoVendas.Application.ViewModels;
using RR.PedidoVendas.Domain.Models;

namespace RR.PedidoVendas.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Item, ItemViewModel>().ReverseMap();
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel> ().ReverseMap();
        }
    }
}
