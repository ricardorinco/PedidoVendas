using RR.PedidoVendas.Domain.Interfaces.Repository;
using RR.PedidoVendas.Domain.Interfaces.Services;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Validation.Produtos;
using System.Collections.Generic;

namespace RR.PedidoVendas.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public Produto Adicionar(Produto produto)
        {
            if (!produto.IsValid())
                return produto;

            produto.ValidationResult = new ProdutoConsistenteValidation().Validate(produto);

            if (!produto.ValidationResult.IsValid)
                return produto;

            return produtoRepository.Adicionar(produto);
        }
        public Produto Atualizar(Produto produto)
        {
            if (!produto.IsValid())
                return produto;

            return produtoRepository.Atualizar(produto);
        }
        public void Remover(int id)
        {
            produtoRepository.Remover(id);
        }

        public Produto SelecionarPorId(int id)
        {
            return produtoRepository.SelecionarPorId(id);
        }
        public IEnumerable<Produto> SelecionarTodos()
        {
            return produtoRepository.SelecionarTodos();
        }

        public void Dispose()
        {
            produtoRepository.Dispose();
        }
    }
}
