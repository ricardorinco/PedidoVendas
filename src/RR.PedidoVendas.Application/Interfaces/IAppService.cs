using RR.PedidoVendas.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace RR.PedidoVendas.Application.Interfaces
{
    public interface IAppService<TEntidade> : IDisposable where TEntidade : EntidadeBaseViewModel
    {
        TEntidade Adicionar(TEntidade entidade);
        TEntidade Atualizar(TEntidade entidade);
        void Remover(int id);

        TEntidade SelecionarPorId(int id);
        IEnumerable<TEntidade> SelecionarTodos();
    }
}
