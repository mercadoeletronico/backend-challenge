using System.Collections.Generic;

namespace MercadoEletronicoApi.Application.DTOs
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public IList<ItemDTO> Items { get; set; } = new List<ItemDTO>();
    }
}
