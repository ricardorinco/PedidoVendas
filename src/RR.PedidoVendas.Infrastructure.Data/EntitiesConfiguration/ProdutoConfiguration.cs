using RR.PedidoVendas.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RR.PedidoVendas.Infrastructure.Data.EntitiesConfiguration
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.Valor)
                .IsRequired();

            Ignore(p => p.ValidationResult);
        }
    }
}
