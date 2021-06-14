using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;
using MinhaAplicacao.Dominio.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MinhaAplicacao.Negocio.Services
{
    public abstract class ServicoBase<TId, TEntidade, TRepositorioBase> : IServicoBase<TId, TEntidade, TRepositorioBase>
        where TId : IEquatable<TId>
        where TEntidade : EntidadeBase<TId>
        where TRepositorioBase : IRepositorioBase<TId, TEntidade>
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly TRepositorioBase _repositorio;

        protected ServicoBase(IUnitOfWork unitOfWork, TRepositorioBase repositorio)
        {
            this._unitOfWork = unitOfWork;
            this._repositorio = repositorio;
        }

        public virtual async Task Inserir(TEntidade entidade)
        {
            if (entidade == null)
            {
                throw new ArgumentNullException(nameof(entidade));
            }

            this._repositorio.Inserir(entidade);
            await this._unitOfWork.Commit();
        }

        public virtual async Task Inserir(List<TEntidade> entidades)
        {
            foreach (var entidade in entidades)
            {
                await this.Inserir(entidade);
            }
        }

        public virtual async Task Alterar(TEntidade entidade)
        {
            if (entidade == null)
            {
                throw new ArgumentNullException(nameof(entidade));
            }

            this._repositorio.Alterar(entidade);
            await this._unitOfWork.Commit();
        }

        public virtual async Task Alterar(List<TEntidade> entidades)
        {
            foreach (var entidade in entidades)
            {
                await this.Alterar(entidade);
            }
        }

        public virtual async Task Deletar(TEntidade entidade)
        {
            if (entidade == null)
            {
                throw new ArgumentNullException(nameof(entidade));
            }

            this._repositorio.Deletar(entidade);
            await this._unitOfWork.Commit();
        }

        public virtual async Task Deletar(List<TEntidade> entidades)
        {
            foreach (var entidade in entidades)
            {
                await this.Deletar(entidade);
            }
        }

        public virtual async Task<TEntidade> SelecionarPorId(TId id, params Expression<Func<TEntidade, object>>[] propriedades)
        {
            return await this._repositorio.SelecionarPorId(id, propriedades).FirstOrDefaultAsync();
        }

        public virtual async Task<List<TEntidade>> SelecionarTodos(params Expression<Func<TEntidade, object>>[] propriedades)
        {
            return await this._repositorio.SelecionarTodos(propriedades).ToListAsync();
        }

        public virtual async Task<List<TEntidade>> SelecionarPor(Expression<Func<TEntidade, bool>> predicado, params Expression<Func<TEntidade, object>>[] propriedades)
        {
            return await this._repositorio.SelecionarPor(predicado, propriedades).ToListAsync();
        }

        public virtual async Task<bool> Existe(Expression<Func<TEntidade, bool>> predicado)
        {
            return await this._repositorio.SelecionarPor(predicado).AnyAsync();
        }

        protected bool ExecutarValidacao<TValidacao>(TValidacao validacao, TEntidade entidade)
            where TValidacao : AbstractValidator<TEntidade>
        {
            var resultado = validacao.Validate(entidade);

            if (!resultado.IsValid)
            {
                //this.Notificar(resultado);
            }

            return resultado.IsValid;
        }
    }
}
