using RR.PedidoVendas.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RR.PedidoVendas.Infrastructure.Data.EntitiesConfiguration
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(14)
                .IsFixedLength();

            Ignore(c => c.ValidationResult);
        }
    }
}
