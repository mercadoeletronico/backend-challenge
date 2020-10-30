using System.Collections.Generic;
using System.Linq;

namespace ME.Pedido.Domain.ValueObjects
{
    public class StatusPedidoResponse
    {
        public string pedido { get; set; }
        public List<string> status { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as StatusPedidoResponse;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return pedido.Equals(compareTo.pedido) && status.SequenceEqual(compareTo.status);
        }
    }
}
