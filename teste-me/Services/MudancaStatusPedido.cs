using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste_me.Models.RequestModels;
using teste_me.Models.ResponseModels;
using teste_me.Repository;
using teste_me.Repository.Context;
using Microsoft.Extensions.Configuration;

namespace teste_me.Services
{
    public class MudancaStatusPedido
    {
        private PedidoRepository _repository;
        private VerificaStatusAprovacao _statusAprovacao;
        private ContabilizaItensPedido _contabilizaItens;
        public MudancaStatusPedido(PedidoRepository repository , VerificaStatusAprovacao statusAprovacao , ContabilizaItensPedido contabilizaItens)
        {
            _repository = repository;
            _statusAprovacao = statusAprovacao;
            _contabilizaItens = contabilizaItens;
        }

        public async Task<ResponseModelMudancaStatusPedido> StatusPedido(RequestModelMudancaStatusPedido request)
        {
            ResponseModelMudancaStatusPedido response = new ResponseModelMudancaStatusPedido();

            try
            {
                var Pedido = await _repository.GetPedido(request.Pedido);
                if (Pedido != null)
                {
                    response.Pedido = request.Pedido.ToString();

                    decimal valorTotal;
                    int quantidadeItens;
                    _contabilizaItens.Verificar(Pedido, out valorTotal, out quantidadeItens);
                    _statusAprovacao.Verificar(request, response, valorTotal, quantidadeItens);

                }
                else
                {
                    response.Pedido = request.Pedido.ToString();
                    response.Status.Add("CODIGO_PEDIDO_INVALIDO");
                }

            }
            catch (Exception)
            {
                throw;
            }


            return response;
        }

    }
}
