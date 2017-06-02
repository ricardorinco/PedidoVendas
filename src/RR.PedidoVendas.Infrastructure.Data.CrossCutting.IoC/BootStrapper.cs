using RR.PedidoVendas.Domain.Interfaces.Repository;
using RR.PedidoVendas.Domain.Interfaces.Services;
using RR.PedidoVendas.Domain.Services;
using RR.PedidoVendas.Infrastructure.Data.Context;
using RR.PedidoVendas.Infrastructure.Data.Interfaces;
using RR.PedidoVendas.Infrastructure.Data.Repositories;
using RR.PedidoVendas.Infrastructure.Data.UoW;
using SimpleInjector;

namespace RR.PedidoVendas.Infrastructure.Data.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void Register(Container container)
        {
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            container.Register<IItemService, ItemService>(Lifestyle.Scoped);
            container.Register<IPedidoService, PedidoService>(Lifestyle.Scoped);
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);

            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IItemRepository, ItemRepository>(Lifestyle.Scoped);
            container.Register<IPedidoRepository, PedidoRepository>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<DataContext>(Lifestyle.Scoped);
        }
    }
}
