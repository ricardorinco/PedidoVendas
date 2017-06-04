using RR.PedidoVendas.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RR.PedidoVendas.Infrastructure.Data.EntitiesConfiguration
{
    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            HasKey(i => i.Id);

            Property(i => i.Quantidade)
                .IsRequired()
                .HasPrecision(5, 2);

            HasRequired(i => i.Produto)
                .WithMany(p => p.Itens)
                .HasForeignKey(i => i.ProdutoId);

            HasRequired(i => i.Pedido)
                .WithMany(p => p.Itens)
                .HasForeignKey(i => i.PedidoId);

            Ignore(i => i.ValidationResult);
        }
    }
}
