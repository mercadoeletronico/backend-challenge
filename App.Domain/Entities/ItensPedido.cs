using System;
using System.Text.Json.Serialization;

namespace App.Domain.Entities
{
    public class ItensPedido
    {
        public ItensPedido()
        {
        }

        public ItensPedido(string descricao, decimal precoUnitario, int qtd, int codigoPedido)
        {
            this.Descricao = descricao;
            this.PrecoUnitario = precoUnitario;
            this.Qtd = qtd;
            this.CodigoPedido = codigoPedido;
        }

        [JsonIgnore]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Qtd { get; set; }
        [JsonIgnore]
        public int CodigoPedido { get; set; }
    }
}
