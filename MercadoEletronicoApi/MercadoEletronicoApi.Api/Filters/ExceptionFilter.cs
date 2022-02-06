using System;
using System.Net;
using MercadoEletronicoApi.Api.ViewModels;
using MercadoEletronicoApi.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MercadoEletronicoApi.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ExceptionFilter : ExceptionFilterAttribute
    {
        private const string MediaType = "application/json";

        /// <summary>
        /// OnException
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            var content = context.Exception.Message;
            HttpStatusCode code;
            
            switch (context.Exception.GetType().Name)
            {
                case nameof(NotFoundPedidoException):
                    code = HttpStatusCode.NotFound;
                    break;
                case nameof(NotDeletedPedidoException):
                    code = HttpStatusCode.UnprocessableEntity;
                    break;
                default:
                    code = HttpStatusCode.BadRequest;
                    content = "Não foi possível processar sua solicitação.";
                    break;
            }

            context.HttpContext.Response.ContentType = MediaType;
            context.HttpContext.Response.StatusCode = (int)code;
            
            var response = new ErrorModel
            {
                Code = (int)code,
                Message = content,
                StackTrace = context.Exception.StackTrace
            };
            context.Result = new ContentResult
            {
                StatusCode = (int)code,
                ContentType = MediaType,
                Content = response.ToJson()
            };
        }
    }
}
