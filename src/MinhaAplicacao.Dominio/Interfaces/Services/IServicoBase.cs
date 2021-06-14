using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MinhaAplicacao.Dominio.Interfaces.Services
{
    public interface IServicoBase<in TId, TEntidade, TRepositorioBase>
        where TId : IEquatable<TId>
        where TEntidade : EntidadeBase<TId>
        where TRepositorioBase : IRepositorioBase<TId, TEntidade>
    {
        Task Inserir(TEntidade entidade);
        Task Inserir(List<TEntidade> entidades);
        Task Alterar(TEntidade entidade);
        Task Alterar(List<TEntidade> entidades);
        Task Deletar(TEntidade entidade);
        Task Deletar(List<TEntidade> entidades);
        Task<TEntidade> SelecionarPorId(TId id, params Expression<Func<TEntidade, object>>[] propriedades);
        Task<List<TEntidade>> SelecionarTodos(params Expression<Func<TEntidade, object>>[] propriedades);
        Task<List<TEntidade>> SelecionarPor(Expression<Func<TEntidade, bool>> predicado, params Expression<Func<TEntidade, object>>[] propriedades);
        Task<bool> Existe(Expression<Func<TEntidade, bool>> predicado);
    }
}
