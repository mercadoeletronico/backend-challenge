using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace teste_me.Models
{
    [Table("item")]
    public class Item
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("preco_unitario")]
        public decimal PrecoUnitario { get; set; }
        [Column("quantidade")]
        public int Quantidade { get; set; }

    }
}
