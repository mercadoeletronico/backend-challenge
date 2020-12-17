using App.Domain.Entities;
using System.Collections.Generic;

namespace App.Domain.Repositories
{
    public interface IPedidosRepository
    {
        void Save(Pedido pedido);
        void Update(Pedido pedido);
    }
}

