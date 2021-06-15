using MercadoEletronico.Teste.Application.Interfaces;
using MercadoEletronico.Teste.Domain.Entities;
using MercadoEletronico.Teste.Domain.Entities.Validations;
using MercadoEletronico.Teste.Infra.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronico.Teste.Application.Services
{
    public class PedidoService : BaseService, IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemRepository _itemRepository;

        public PedidoService(IPedidoRepository pedidoRepository,
                             IItemRepository itemRepository,
                             INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _itemRepository = itemRepository;
        }

        public async Task Adicionar(Pedido pedido)
        {
            await _pedidoRepository.Adicionar(pedido);

            pedido.Itens.ToList().ForEach(async i => {
                if (!ExecutarValidacao(new ItemValidation(), i)) return;
                 await _itemRepository.Adicionar(i);
            });
        }

        public async Task Atualizar(Pedido pedido)
        {
            await _pedidoRepository.Atualizar(pedido);

            pedido.Itens.ToList().ForEach(async i => {
                if (!ExecutarValidacao(new ItemValidation(), i)) return;
                await _itemRepository.Atualizar(i);
            });
        }

        public async Task Remover(Guid id)
        {
            await _pedidoRepository.Remover(id);
        }

        public void Dispose()
        {
            _pedidoRepository?.Dispose();
        }
    }
}