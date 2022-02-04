using Newtonsoft.Json;

namespace MercadoEletronico.Domain.Requests
{
    public class PedidoItemRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal? PrecoUnitario { get; set; }
        public uint Qtd { get; set; }
    }
}