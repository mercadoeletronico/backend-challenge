using AutoMapper;
using FluentValidation.Results;
using ME.PurchaseOrder.Domain.Interfaces;
using ME.PurchaseOrder.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ME.PurchaseOrder.Domain.Commands.Handlers
{
    public class OrderCommandHandler : CommandHandler,
        IRequestHandler<CreateOrderCommand, ValidationResult>,
        IRequestHandler<UpdateOrderCommand, ValidationResult>,
        IRequestHandler<DeleteOrderCommand, ValidationResult>,
        IRequestHandler<UpdateOrderStatusCommand, ValidationResult>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(IMapper mapper, IOrderRepository orderRepository) : base()
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<ValidationResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            => await ValidatedAndCommit(_orderRepository.UnitOfWork, request, command =>
            {
                var duplicity = _orderRepository.GetOrderByCode(request.NumberOrder).GetAwaiter().GetResult() is not null;

                var entity = _mapper.Map<Order>(request);

                if (duplicity)
                    AddError(Enums.ErrorCode.NumberCodeOrderInvalid, "Já existe um pedido com este número.");
                else
                    _orderRepository.Insert(entity);
            });

        public async Task<ValidationResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
            => await ValidatedWithTargetAndCommit(_orderRepository.UnitOfWork, request,
                async () => await _orderRepository.GetOrderByCode(request.NumberOrder),
                (command, target) =>
                {
                    var entity = _mapper.Map<Order>(request);

                    entity.Id = target.Id;

                    _orderRepository.Update(entity);
                });

        public async Task<ValidationResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
            => await ValidatedWithTargetAndCommit(_orderRepository.UnitOfWork, request,
                async () => await _orderRepository.GetOrderByCode(request.NumberOrder),
                (command, target) => _orderRepository.Delete(target));

        public async Task<ValidationResult> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
            => await ValidatedWithTargetAndCommit(_orderRepository.UnitOfWork, request,
                async () => await _orderRepository.GetOrderByCode(request.NumberOrder),
                (command, target) =>
                {
                    target.Status = request.Status;

                    _orderRepository.Update(target);
                });
    }
}