using AutoMapper;

namespace RR.PedidoVendas.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile<DomainToViewModelMappingProfile>();
            });
        }
    }
}
