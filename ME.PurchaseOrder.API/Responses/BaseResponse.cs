using ME.PurchaseOrder.Domain.Enums;
using ME.PurchaseOrder.Domain.Extensions;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ME.PurchaseOrder.API.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
        }

        public BaseResponse(int statusCode)
        {
            this.StatusCode = statusCode;
        }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<string> Mensagem { get; set; }

        public List<string> Status { get; set; }

        public void AddError(string errorCodeDescription, string message = null)
        {
            if (Status is null)
                Status = new List<string>();

            Status.Add(errorCodeDescription);

            if (!string.IsNullOrWhiteSpace(message))
            {
                if (Mensagem is null)
                    Mensagem = new List<string>();

                Mensagem.Add(message);
            }
        }

        public void AddError(ErrorCode errorCode, string message = null)
            => AddError(errorCode.GetDescription(), message);
    }
}