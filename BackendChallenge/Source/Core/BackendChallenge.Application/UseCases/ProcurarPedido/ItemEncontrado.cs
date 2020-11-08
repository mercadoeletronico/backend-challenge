using BackendChallenge.Entities;

namespace BackendChallenge.Application.UseCases
{
    public class ItemEncontrado
    {
        public string Descricao { get; set; }

        public int PrecoUnitario { get; set; }

        public int Qtd { get; set; }

        public static ItemEncontrado ConvertFrom(OrderItem orderItem)
        {
            return new ItemEncontrado
            {
                Descricao = orderItem.Description,
                Qtd = orderItem.Quantity,
                PrecoUnitario = orderItem.UnitPrice
            };
        }
    }
}
