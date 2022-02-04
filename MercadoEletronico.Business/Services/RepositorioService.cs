using AutoMapper;

namespace MercadoEletronico.Business.Services
{
    public class RepositorioService : Interfaces.IRepositorioService
    {
        private readonly Interfaces.INotificador _Notificador;

        private readonly IMapper _Mapper;

        private readonly DataAccess.Context _Context;

        public RepositorioService(Interfaces.INotificador notificador, IMapper mapper, DataAccess.Context contexto)
        {
            _Notificador = notificador;
            _Mapper = mapper;
            _Context = contexto;
        }

        private Entities.PedidoService _Pedido;

        public Entities.PedidoService Pedido
        {
            get
            {
                return _Pedido == null ? _Pedido = new Entities.PedidoService(_Notificador, _Mapper) : _Pedido;
            }
        }

        public bool Connection()
        {
            try
            {
                _Context.Database.CanConnect();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}