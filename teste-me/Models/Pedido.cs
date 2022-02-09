using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace teste_me.Models
{
    [Table("pedido")]
    public class Pedido
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }
        [ForeignKey("item_id")]
        public List<Item> Itens { get; set; }
    }
}
