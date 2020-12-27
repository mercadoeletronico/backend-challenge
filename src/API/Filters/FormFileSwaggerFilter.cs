using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Web.Filters
{
    /// <summary>
    /// Filter to enable handling file upload in swagger
    /// </summary>
    public class FormFileSwaggerFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (!(operation?.RequestBody?.Content?.Any(x => x.Key.ToLower() == "multipart/form-data") ?? false)) return;

            if (context.MethodInfo.DeclaringType != null)
            {
                var uploadFiles = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                    .Union(context.MethodInfo.GetCustomAttributes(true))
                    .OfType<SwaggerUploadFile>();

                if (uploadFiles.Count() == 0) return;

                var uploadFile = uploadFiles.First();

                operation.RequestBody.Content["multipart/form-data"].Schema.Properties =
                    new Dictionary<string, OpenApiSchema>
                    {
                        [uploadFile.Parameter] = new OpenApiSchema
                        {
                            Type = "string",
                            Format = "binary",
                            Description = uploadFile.Description
                        }
                    };

                if (!string.IsNullOrEmpty(uploadFile.Example))
                {
                    operation.RequestBody.Content["multipart/form-data"].Schema.Example = new OpenApiString(uploadFile.Example);
                    operation.RequestBody.Content["multipart/form-data"].Schema.Description = uploadFile.Example;
                }
            }
        }

        private class SwaggerUploadFile
        {
            public string Parameter { get; }

            public string Description { get; }

            public string Example { get; }
        }
    }
}
