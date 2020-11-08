using System;

using BackendChallenge.Entities;

using MediatR;

namespace BackendChallenge.Application.UseCases
{
    public class AlterarStatusDoPedido : IRequest<StatusDoPedido>
    {
        public string Status { get; set; }

        public int ItensAprovados { get; set; }

        public int ValorAprovado { get; set; }

        public string Pedido { get; set; }

        internal static OrderStatus ConvertTo(AlterarStatusDoPedido viewModel)
        {
            return new OrderStatus
            {
                OrderNumber = viewModel.Pedido,
                ApprovedQuantity = viewModel.ItensAprovados,
                ApprovedPrice = viewModel.ValorAprovado,
                Status = Enum.Parse<Status>(viewModel.Status)
            };
        }
    }
}
