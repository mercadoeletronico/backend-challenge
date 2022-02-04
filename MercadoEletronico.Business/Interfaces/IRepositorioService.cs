namespace MercadoEletronico.Business.Interfaces
{
    public interface IRepositorioService
    {
        Services.Entities.PedidoService Pedido { get; }

        bool Connection();
    }
}
