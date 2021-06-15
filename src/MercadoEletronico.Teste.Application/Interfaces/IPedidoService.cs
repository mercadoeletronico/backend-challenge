using MercadoEletronico.Teste.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MercadoEletronico.Teste.Application.Interfaces
{
    public interface IPedidoService : IDisposable
    {
        Task Adicionar(Pedido pedido);
        Task Atualizar(Pedido pedido);
        Task Remover(Guid id);
    }
}