using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoEletronico.Domain.Entities
{
    public class PedidoItem : IEntity
    {
        public int Id { get; set; }

        public int IdPedido { get; set; }

        [ForeignKey("IdPedido")]
        public virtual Pedido Pedido { get; set; }

        public string Descricao { get; set; }

        public decimal PrecoUnitario { get; set; }

        public int Qtd { get; set; }
    }
}