using System;
using System.Collections.Generic;

namespace MercadoEletronico.Challenge.Util.Extensions
{
    public static class ExceptionExtensions
    {
        public static ResultStatus GetResultStatus(this Exception exception) 
        {
            var status = exception switch
            {
                ArgumentException _ => ResultStatus.BadRequest,
                KeyNotFoundException _ => ResultStatus.NotFound,
                _ => ResultStatus.InternalError,
            };

            return status;
        }
    }
}
