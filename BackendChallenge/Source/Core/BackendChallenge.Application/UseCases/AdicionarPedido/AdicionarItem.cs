using BackendChallenge.Entities;

namespace BackendChallenge.Application.UseCases
{
    public class AdicionarItem
    {
        public string Descricao { get; set; }

        public int PrecoUnitario { get; set; }

        public int Qtd { get; set; }

        public static OrderItem ConverTo(AdicionarItem orderItem)
        {
            return new OrderItem
            {
                Description = orderItem.Descricao,
                Quantity = orderItem.Qtd,
                UnitPrice = orderItem.PrecoUnitario
            };
        }
    }
}
