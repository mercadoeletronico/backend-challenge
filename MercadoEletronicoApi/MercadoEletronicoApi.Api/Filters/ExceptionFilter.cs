using System;
using System.Net;
using MercadoEletronicoApi.Api.ViewModels;
using MercadoEletronicoApi.Application.Utils;
using MercadoEletronicoApi.Domain.Exceptions;
using MercadoEletronicoApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MercadoEletronicoApi.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ExceptionFilter : ExceptionFilterAttribute
    {
        private const string MediaType = "application/json";

        public override void OnException(ExceptionContext context)
        {
            var content = context.Exception.Message;
            HttpStatusCode code;

            switch (context.Exception.GetType().Name)
            {
                case nameof(NotFoundPedidoException):
                    code = HttpStatusCode.NotFound;
                    break;
                case nameof(NotDeletedOrderException):
                    code = HttpStatusCode.UnprocessableEntity;
                    break;
                case nameof(OrderAlreadyExistsException):
                    code = HttpStatusCode.UnprocessableEntity;
                    break;
                default:
                    code = HttpStatusCode.BadRequest;
                    content = Constantes.UnprocessedRequest;
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
