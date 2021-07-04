using System.Collections.Generic;

namespace backend_challenge_datatypes.Responses
{
    public class GetOrderResponse
    {
        public string pedido {get ;set; }
        public List<GetOrderItemResponse> itens { get; set; }
    }
}