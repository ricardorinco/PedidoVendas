using RR.PedidoVendas.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RR.PedidoVendas.Infrastructure.Data.EntitiesConfiguration
{
    public class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.DataEntrega)
                .IsRequired();

            Property(p => p.NumeroControle)
                .IsRequired();

            Ignore(p => p.ValidationResult);
        }
    }
}
