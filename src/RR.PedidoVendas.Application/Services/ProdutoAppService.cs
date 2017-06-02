using AutoMapper;
using RR.PedidoVendas.Application.Interfaces;
using RR.PedidoVendas.Application.ViewModels;
using RR.PedidoVendas.Domain.Interfaces.Services;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace RR.PedidoVendas.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoService produtoService;
        private readonly IUnitOfWork unitOfWork;

        public ProdutoAppService(IProdutoService produtoService, IUnitOfWork unitOfWork)
        {
            this.produtoService = produtoService;
            this.unitOfWork = unitOfWork;
        }

        public ProdutoViewModel Adicionar(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<Produto>(produtoViewModel);
            var produtoRetornado = produtoService.Adicionar(produto);

            if (produtoRetornado.ValidationResult.IsValid)
                unitOfWork.Commit();

            produtoViewModel = Mapper.Map<ProdutoViewModel>(produtoRetornado);

            return produtoViewModel;
        }
        public ProdutoViewModel Atualizar(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<Produto>(produtoViewModel);
            var produtoRetornado = produtoService.Atualizar(produto);

            if (produtoRetornado.ValidationResult.IsValid)
                unitOfWork.Commit();

            produtoViewModel = Mapper.Map<ProdutoViewModel>(produtoRetornado);

            return produtoViewModel;
        }
        public void Remover(int id)
        {
            produtoService.Remover(id);
            unitOfWork.Commit();
        }

        public ProdutoViewModel SelecionarPorId(int id)
        {
            return Mapper.Map<ProdutoViewModel>(produtoService.SelecionarPorId(id));
        }
        public IEnumerable<ProdutoViewModel> SelecionarTodos()
        {
            return Mapper.Map<IEnumerable<ProdutoViewModel>>(produtoService.SelecionarTodos());
        }

        public void Dispose()
        {
            produtoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
