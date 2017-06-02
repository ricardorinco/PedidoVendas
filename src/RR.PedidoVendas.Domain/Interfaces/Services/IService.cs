using RR.PedidoVendas.Domain.Models;
using System;
using System.Collections.Generic;

namespace RR.PedidoVendas.Domain.Interfaces.Services
{
    public interface IService<TEntidade> : IDisposable where TEntidade : EntidadeBase
    {
        TEntidade Adicionar(TEntidade entidade);
        TEntidade Atualizar(TEntidade entidade);
        void Remover(int id);

        TEntidade SelecionarPorId(int id);
        IEnumerable<TEntidade> SelecionarTodos();
    }
}
