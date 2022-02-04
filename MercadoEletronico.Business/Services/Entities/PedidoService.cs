using AutoMapper;
using MercadoEletronico.Domain.Entities;
using MercadoEletronico.Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronico.Business.Services.Entities
{
    public class PedidoService : RepositorioBaseService<DataAccess.Context, Domain.Entities.Pedido>
    {
        private readonly IMapper _Mapper;

        public PedidoService(Interfaces.INotificador notificador, IMapper mapper) : base(notificador)
        {
            _Mapper = mapper;
        }

        public async Task<List<Domain.Requests.PedidoRequest>> GetAllAsync()
        {
            List<Domain.Entities.Pedido> listaPedido = await base.GetAllAsync();

            List<Domain.Requests.PedidoRequest> listaPedidoRequest = _Mapper.Map<List<Domain.Entities.Pedido>, List<Domain.Requests.PedidoRequest>>(listaPedido);

            return listaPedidoRequest;
        }

        public async Task<Domain.Requests.PedidoRequest> AddAsync(Domain.Requests.PedidoRequest pedidoRequest)
        {
            Domain.Entities.Pedido pedido = _Mapper.Map<Domain.Entities.Pedido>(pedidoRequest);

            await base.AddAsync(pedido);

            return _Mapper.Map<Domain.Requests.PedidoRequest>(pedido);
        }

        public virtual async Task<Domain.Requests.PedidoRequest> GetByIdAsync(int id)
        {
            Domain.Entities.Pedido pedido = await base.GetByIdAsync(id);

            if (pedido == null)
            {
                Notificar("O pedido informado não foi encontrado");

                return null;
            }
            else
            {
                Domain.Requests.PedidoRequest pedidoRequest = _Mapper.Map<Domain.Requests.PedidoRequest>(pedido);

                return pedidoRequest;
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            Domain.Entities.Pedido pedido = await base.GetByIdAsync(id);

            if (pedido == null)
                Notificar("O pedido informado não foi encontrado");
        }

        public async Task<Domain.Requests.PedidoRequest> UpdateAsync(Domain.Requests.PedidoRequest pedidoRequest)
        {
            Domain.Entities.Pedido pedido = _Mapper.Map<Domain.Entities.Pedido>(pedidoRequest);

            await base.UpdateAsync(pedido);

            return _Mapper.Map<Domain.Requests.PedidoRequest>(pedido);
        }

        public async Task DeleleAllAsync()
        {
            List<Domain.Entities.Pedido> listaPedido = await base.GetAllAsync();

            await base.DeleteRangeAsync(listaPedido);
        }

        public virtual async Task<Domain.Responses.StatusResponse> AprovarPedido(Domain.Requests.StatusRequest request)
        {
            if (request.Status.NotIn(Domain.Enums.StatusAprovacao.Aprovado.GetDescription(), Domain.Enums.StatusAprovacao.Reprovado.GetDescription()))
            {
                Notificar($"{typeof(Domain.Requests.StatusRequest).Name} deve conter um valor igual a '{Domain.Enums.StatusAprovacao.Aprovado.GetDescription()}' or '{Domain.Enums.StatusAprovacao.Reprovado.GetDescription()}'");

                return null;
            }

            Domain.Responses.StatusResponse response = new() { Pedido = request.Pedido };

            Domain.Entities.Pedido pedido = await base.GetByIdAsync(request.Pedido);

            if (pedido is null)
            {
                response.Status.Add(Domain.Enums.StatusAprovacao.PedidoInvalido.GetDescription());

                return response;
            }

            if (request.Status == Domain.Enums.StatusAprovacao.Reprovado.GetDescription())
            {
                response.Status.Add(request.Status);

                return response;
            }

            Domain.Enums.StatusAprovacao aprovacaoValor = VerificarValorAprovado(request.ValorAprovado, pedido.Itens.Sum(p => p.PrecoUnitario * p.Qtd));

            Domain.Enums.StatusAprovacao aprovacaoQuantidade = VerificarQuantidadeAprovada(request.ItensAprovados,pedido.Itens.Sum(p => p.Qtd));

            if (aprovacaoValor is Domain.Enums.StatusAprovacao.Aprovado && aprovacaoQuantidade is Domain.Enums.StatusAprovacao.Aprovado)
            {
                response.Status.Add(Domain.Enums.StatusAprovacao.Aprovado.GetDescription());
                return response;
            }

            if (aprovacaoValor is not Domain.Enums.StatusAprovacao.Aprovado)
            {
                response.Status.Add(aprovacaoValor.GetDescription());
            }

            if (aprovacaoQuantidade is not Domain.Enums.StatusAprovacao.Aprovado)
            {
                response.Status.Add(aprovacaoQuantidade.GetDescription());
            }

            return response;
        }

        private static Domain.Enums.StatusAprovacao VerificarValorAprovado(decimal? aprovacao, decimal pedido)
        {
            return VerificarAprovada(aprovacao, pedido, Domain.Enums.StatusAprovacao.AprovadoValorMenor, Domain.Enums.StatusAprovacao.AprovadoValorMaior);
        }

        public static Domain.Enums.StatusAprovacao VerificarQuantidadeAprovada(decimal? aprovacao, decimal pedido)
        {
            return VerificarAprovada(aprovacao, pedido, Domain.Enums.StatusAprovacao.AprovadoQuantidadeMenor, Domain.Enums.StatusAprovacao.AprovadoQuantidadeMaior);
        }

        private static Domain.Enums.StatusAprovacao VerificarAprovada(decimal? aprovacao, decimal pedido, Domain.Enums.StatusAprovacao quantidadeMenor, Domain.Enums.StatusAprovacao quantidadeMaior)
        {
            if (pedido is <= 0)
            {
                return Domain.Enums.StatusAprovacao.Aprovado;
            }

            if (aprovacao is null || aprovacao < pedido)
            {
                return quantidadeMenor;
            }

            if (aprovacao == pedido)
            {
                return Domain.Enums.StatusAprovacao.Aprovado;
            }

            return quantidadeMaior;
        }

        protected override IIncludableQueryable<Pedido, object> DefaultInclusions(DbSet<Pedido> dbSet)
        {
            return dbSet.Include(p => p.Itens);
        }
    }
}
