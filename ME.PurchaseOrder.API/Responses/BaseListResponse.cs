using System.Collections.Generic;

namespace ME.PurchaseOrder.API.Responses
{
    public class BaseListResponse<T> : BaseResponse where T : class
    {
        public BaseListResponse()
        {
        }

        public BaseListResponse(int statusCode) : base(statusCode)
        {
        }

        public ICollection<T> Itens { get; set; }
    }
}