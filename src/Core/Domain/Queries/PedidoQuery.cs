using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Enum;
using Domain.Notifications;
using Domain.Repositories;

namespace Domain.Queries
{
    public class PedidoQuey : IPedidoQuery
    {
        private readonly NotificationPool _notificationPool;
        private readonly IPedidoQueryRepository _pedidoQueryRepository;
        public bool HasNotifications => _notificationPool.HasNotifications;

        public IReadOnlyCollection<Notification> Notifications => _notificationPool.Notifications;

        public PedidoQuey(NotificationPool notificationPool, IPedidoQueryRepository pedidoQueryRepository)
        {
            _notificationPool = notificationPool;
            _pedidoQueryRepository = pedidoQueryRepository;
        }


        IEnumerable<Pedido> IPedidoQuery.ListarPedido()
        {
            return _pedidoQueryRepository.ListarPedido();
        }

        public void RemoverPedido(string numeroPedido)
        {
            _pedidoQueryRepository.RemoverPedido(numeroPedido);
        }

        public Pedido ListarPedidoByID(string idPedido)
        {
            return _pedidoQueryRepository.ListarPedidoByID(idPedido);
        }

        public StatusPedido VerificarStatusPedido(string status, int itensAprovados, double valorAprovado, string pedido)
        {
            var pedidoResponse = _pedidoQueryRepository.ListarPedidoByID(pedido); ;
            var statusMensagem = new StatusPedido
            {
                Pedido = pedido,
                Status = new List<string>()
            };
            if (pedidoResponse == null || pedidoResponse.NumeroPedido != pedido)
            {
                statusMensagem.Status.Add(StatusPedidoEnum.CodigoPedidoInvalido.ToDescriptionString());
                return statusMensagem;
            }
            else if (status.ToUpper() == StatusPedidoEnum.Reprovado.ToDescriptionString())
            {
                statusMensagem.Status.Add(StatusPedidoEnum.Reprovado.ToDescriptionString());
                return statusMensagem;
            }
            if (status.ToUpper() == StatusPedidoEnum.Aprovado.ToDescriptionString())
            {
                if (pedidoResponse.PedidoItens.Sum(x => x.Quantidade) == itensAprovados && pedidoResponse.PedidoItens.Sum(x => x.PrecoUnitario * x.Quantidade) == valorAprovado)
                    statusMensagem.Status.Add(StatusPedidoEnum.Aprovado.ToDescriptionString());
                if (pedidoResponse.PedidoItens.Sum(x => x.PrecoUnitario * x.Quantidade) > valorAprovado)
                    statusMensagem.Status.Add(StatusPedidoEnum.AprovadoValorAMenor.ToDescriptionString());

                if (pedidoResponse.PedidoItens.Sum(x => x.PrecoUnitario * x.Quantidade) < valorAprovado)
                    statusMensagem.Status.Add(StatusPedidoEnum.AprovadoValorAMaior.ToDescriptionString());

                if (pedidoResponse.PedidoItens.Sum(x => x.Quantidade) > itensAprovados)
                    statusMensagem.Status.Add(StatusPedidoEnum.AprovadoQtdAMenor.ToDescriptionString());


                if (pedidoResponse.PedidoItens.Sum(x => x.Quantidade) < itensAprovados)
                    statusMensagem.Status.Add(StatusPedidoEnum.AprovadoQtdAMaior.ToDescriptionString());

                return statusMensagem;

            }
            statusMensagem.Status.Add(StatusPedidoEnum.Reprovado.ToDescriptionString());
            return statusMensagem;
        }
    }
}