using RR.PedidoVendas.Domain.Interfaces.Repository;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RR.PedidoVendas.Infrastructure.Data.Repositories
{
    public abstract class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : EntidadeBase, new()
    {
        protected DataContext Context;
        protected DbSet<TEntidade> DbSet;

        protected Repository(DataContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntidade>();
        }

        public virtual TEntidade Adicionar(TEntidade entidade)
        {
            var novaEntidade = DbSet.Add(entidade);

            return novaEntidade;
        }
        public virtual TEntidade Atualizar(TEntidade entidade)
        {
            var objEntidade = Context.Entry(entidade);
            DbSet.Attach(entidade);
            objEntidade.State = EntityState.Modified;

            return entidade;
        }
        public virtual void Remover(int id)
        {
            var entidade = DbSet.Find(id);
            DbSet.Remove(entidade);
        }

        public virtual TEntidade SelecionarPorId(int id)
        {
            return DbSet.Find(id);
        }
        public virtual IEnumerable<TEntidade> SelecionarTodos()
        {
            return DbSet.ToList();
        }

        public int SalvarAlteracoes()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
