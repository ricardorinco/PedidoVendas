using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Infrastructure.Data.Context;
using System.Data.Entity.Migrations;

namespace RR.PedidoVendas.Infrastructure.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext context)
        {
            #region Clientes
            context.Clientes.AddOrUpdate(x => x.Nome,
                new Cliente { Nome = "Douglas Santos", CPF = "935.083.153-80" },
                new Cliente { Nome = "Maria Medeiros", CPF = "223.157.286-90" },
                new Cliente { Nome = "Caio Silva", CPF = "385.538.177-17" },
                new Cliente { Nome = "Elizabeth Almeida", CPF = "689.259.384-48" },
                new Cliente { Nome = "Renata Rodrigues", CPF = "415.358.016-38" },
                new Cliente { Nome = "Antônio Carlos", CPF = "104.651.551-97" },
                new Cliente { Nome = "Odete Martins", CPF = "959.183.554-05" },
                new Cliente { Nome = "Larissa de Jesus", CPF = "944.437.976-02" },
                new Cliente { Nome = "Matheus Kirchner", CPF = "164.271.726-62" },
                new Cliente { Nome = "Mayara Johnson", CPF = "395.172.077-86" }
            );
            #endregion

            #region Produtos
            context.Produtos.AddOrUpdate(x => x.Descricao,
                new Produto { Descricao = "Game Horizon Zero Dawn - PS4", Valor = 199.99m },
                new Produto { Descricao = "Box - Marvel: Guerra Civil e Guerras Secretas (Edição Slim) + Pôster", Valor = 19.90m },
                new Produto { Descricao = "Bicicleta Specialized Status FSR I P", Valor = 11399.00m },
                new Produto { Descricao = "Pneu 195/60r15 Extremecontact Dw 88h Continental", Valor = 261.28m },
                new Produto { Descricao = "Kit Livros - Especial Game of Thrones - Capa Exclusiva", Valor = 44.90m },
                new Produto { Descricao = "Snack Fruits Com 6 Unidade Bio2", Valor = 31.36m },
                new Produto { Descricao = "Game Battlefield 1 - PS4", Valor = 199.99m }, 
                new Produto { Descricao = "Smartwatch Samsung Gear Fit 2 Pulseira P Preto", Valor = 999.99m },
                new Produto { Descricao = "Fone de Ouvido Beats Urbeats 2 Earphone Preto", Valor = 186.90m },
                new Produto { Descricao = "Sensor Estacionamento 4 Pontos Branco Display Led Colorido", Valor = 44.90m }
            );
            #endregion
        }
    }
}
