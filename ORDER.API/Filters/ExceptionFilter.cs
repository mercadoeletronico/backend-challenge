using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ORDER.API.ViewModels;
using ORDER.Domain.Exceptions;
using ORDER.Infra.Extensions;

namespace ORDER.API.Filters
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
                case nameof(NotFoundOrderException):
                    code = HttpStatusCode.NotFound;
                    break;
                case nameof(RequestNotValid):
                    code = HttpStatusCode.UnprocessableEntity;
                    break;
                case nameof(UnauthorizedAccessException):
                    code = HttpStatusCode.Unauthorized;
                    break;
                default:
                    code = HttpStatusCode.BadRequest;
                    content = "Something is wrong. Your Request could not be processed.";
                    break;
            }

            context.HttpContext.Response.ContentType = MediaType;
            context.HttpContext.Response.StatusCode = (int) code;
            var response = new ErrorModel
            {
                Code = (int) code,
                Message = content,
                StackTrace = context.Exception.StackTrace
            };
            context.Result = new ContentResult
            {
                StatusCode = (int) code,
                ContentType = MediaType,
                Content = response.ToJson()
            };
        }
    }
}