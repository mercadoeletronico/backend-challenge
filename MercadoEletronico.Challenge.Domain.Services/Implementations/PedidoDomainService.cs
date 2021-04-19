using MercadoEletronico.Challenge.Domain.Models.Entities;
using MercadoEletronico.Challenge.Domain.Models.Enums;
using MercadoEletronico.Challenge.Domain.Models.Requests;
using MercadoEletronico.Challenge.Domain.Models.Responses;
using MercadoEletronico.Challenge.Domain.Services.Interfaces;
using MercadoEletronico.Challenge.Domain.Services.Interfaces.Data_Access;
using MercadoEletronico.Challenge.Util.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.Domain.Services.Implementations
{
    public class PedidoDomainService : DomainService<Pedido>, IPedidoDomainService
    {
        public PedidoDomainService(IPedidoRepository repository) : base(repository)
        {
        }

        public async Task<StatusResponse> AprovarPedido(StatusRequest request)
        {
            if (request.Status.NotIn(
                StatusAprovacao.Aprovado.GetDescription(),
                StatusAprovacao.Reprovado.GetDescription()))
            {
                throw new ArgumentException($"{typeof(StatusRequest).Name} must have value equal to '{StatusAprovacao.Aprovado.GetDescription()}' or '{StatusAprovacao.Reprovado.GetDescription()}'", nameof(request));
            }

            StatusResponse response = new() { Pedido = request.Pedido };

            var pedido = await GetByIdAsync(request.Pedido);

            if (pedido is null)
            {
                response.Status.Add(StatusAprovacao.PedidoInvalido.GetDescription());
                return response;
            }

            if (request.Status == StatusAprovacao.Reprovado.GetDescription())
            {
                response.Status.Add(request.Status);
                return response;
            }

            var aprovacaoValor = VerificarValorAprovado(
                request.ValorAprovado,
                pedido.Itens.Sum(p => p.PrecoUnitario * p.Qtd));

            var aprovacaoQuantidade = VerificarQuantidadeAprovada(
                request.ItensAprovados,
                pedido.Itens.Sum(p => p.Qtd));

            if (aprovacaoValor is StatusAprovacao.Aprovado
                && aprovacaoQuantidade is StatusAprovacao.Aprovado)
            {
                response.Status.Add(StatusAprovacao.Aprovado.GetDescription());
                return response;
            }

            if (aprovacaoValor is not StatusAprovacao.Aprovado)
            {
                response.Status.Add(aprovacaoValor.GetDescription());
            }

            if (aprovacaoQuantidade is not StatusAprovacao.Aprovado)
            {
                response.Status.Add(aprovacaoQuantidade.GetDescription());
            }

            return response;
        }

        public static StatusAprovacao VerificarQuantidadeAprovada(decimal? aprovacao, decimal pedido)
            => VerificarAprovada(
                aprovacao,
                pedido,
                StatusAprovacao.AprovadoQuantidadeMenor,
                StatusAprovacao.AprovadoQuantidadeMaior);

        public static StatusAprovacao VerificarValorAprovado(decimal? aprovacao, decimal pedido)
            => VerificarAprovada(
                aprovacao,
                pedido,
                StatusAprovacao.AprovadoValorMenor,
                StatusAprovacao.AprovadoValorMaior);

        private static StatusAprovacao VerificarAprovada(
            decimal? aprovacao,
            decimal pedido,
            StatusAprovacao quantidadeMenor,
            StatusAprovacao quantidadeMaior)
        {
            if (pedido is <= 0)
            {
                return StatusAprovacao.Aprovado;
            }

            if (aprovacao is null || aprovacao < pedido)
            {
                return quantidadeMenor;
            }

            if (aprovacao == pedido)
            {
                return StatusAprovacao.Aprovado;
            }

            return quantidadeMaior;
        }
    }
}
