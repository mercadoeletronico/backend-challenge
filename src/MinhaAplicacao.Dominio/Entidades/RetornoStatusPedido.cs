using System.Collections.Generic;

namespace MinhaAplicacao.Dominio.Entidades
{
    public class RetornoStatusPedido
    {
        public string Pedido { get; set; }
        public List<string> Status { get; set; }
    }
}
