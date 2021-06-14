using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;
using MinhaAplicacao.Dominio.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaAplicacao.Negocio.Services
{
    public class PedidoServico : ServicoBase<int, Pedido, IPedidoRepositorio>, IPedidoServico
    {
        public PedidoServico(IUnitOfWork unitOfWork, IPedidoRepositorio repositorio)
            : base(unitOfWork, repositorio)
        {
        }

        public async Task<RetornoStatusPedido> ValidarPedido(StatusPedido statusPedido)
        {
            var pedido = await this._repositorio.SelecionarPorNumero(statusPedido.Pedido, p => p.ItensPedidos);

            var statusRetorno = new List<string>();

            if (pedido == null)
            {
                statusRetorno.Add("CODIGO_PEDIDO_INVALIDO");
            }
            else if (statusPedido.Status.Equals("REPROVADO"))
            {
                statusRetorno.Add("REPROVADO");
            }
            else
            {
                if (statusPedido.Status.Equals("APROVADO") &&
                    pedido.ValidarIgualItemAprovado(statusPedido.ItensAprovados) &&
                    pedido.ValidarIgualValorAprovado(statusPedido.ValorAprovado))
                {
                    statusRetorno.Add("APROVADO");
                }
                if (statusPedido.Status.Equals("APROVADO") &&
                    pedido.ValidarMenorValorAprovado(statusPedido.ValorAprovado))
                {
                    statusRetorno.Add("APROVADO_VALOR_A_MENOR");
                }
                if (statusPedido.Status.Equals("APROVADO") &&
                    pedido.ValidarMenorItemAprovado(statusPedido.ItensAprovados))
                {
                    statusRetorno.Add("APROVADO_QTD_A_MENOR");
                }
                if (statusPedido.Status.Equals("APROVADO") &&
                    pedido.ValidarMaiorValorAprovado(statusPedido.ValorAprovado))
                {
                    statusRetorno.Add("APROVADO_VALOR_A_MAIOR");
                }
                if (statusPedido.Status.Equals("APROVADO") &&
                    pedido.ValidarMaiorItemAprovado(statusPedido.ItensAprovados))
                {
                    statusRetorno.Add("APROVADO_QTD_A_MAIOR");
                }
            }

            return new RetornoStatusPedido
            {
                Pedido = statusPedido.Pedido,
                Status = statusRetorno
            };
        }
    }
}
