﻿using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MinhaApiCompleta.Api.Extensions
{
    public class ExceptionMiddleware
    {
        #region Propriedades

        private readonly RequestDelegate _next;

        #endregion

        #region Construtor

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion

        #region Metodos

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            exception.Ship(context);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return Task.CompletedTask;
        }

        #endregion
    }
}
