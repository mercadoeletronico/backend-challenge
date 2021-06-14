using System.Collections.Generic;

namespace MinhaAplicacao_API.V1.Models
{
    public class PedidoModel : ModelBase<int>
    {
        public string Numero { get; set; }

        public IEnumerable<ItemPedidoModel> ItensPedidos { get; set; }
    }
}
