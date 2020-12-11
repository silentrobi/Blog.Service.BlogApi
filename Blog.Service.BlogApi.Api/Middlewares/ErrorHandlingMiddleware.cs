using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net;
using Blog.Service.BlogApi.Application.ErrorModels;
using Blog.Service.BlogApi.Application.Exceptions;
using System.Collections.Generic;
using Blog.Service.BlogApi.Application.ResponseModels.Error;

namespace Blog.Service.BlogApi.Api.Middlewares
{
    public  class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var validationResponseModel = new ValidationResponse();
            var applicationResponseModel = new ApplicationResponse();

            string result = "";

            switch (exception)
            {
                case Application.Exceptions.ApplicationException e:

                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    applicationResponseModel.Message = e.Message;
                    result = JsonSerializer.Serialize(applicationResponseModel);
                    break;

                case ValidationException e:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    validationResponseModel.Errors = e.Errors;
                    result = JsonSerializer.Serialize(validationResponseModel);
                    break;

                case KeyNotFoundException e:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            
            return response.WriteAsync(result);
        }
    }
}
