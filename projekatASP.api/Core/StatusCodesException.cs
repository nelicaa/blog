﻿using ASPNedelja3.Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using projekatASP.application.Exceptions;
using projekatASP.application.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekatASP.api.Core
{
    public class StatusCodesException {
     private readonly RequestDelegate _next;
    private readonly IExceptionLogger _logger;

    public StatusCodesException(RequestDelegate next, IExceptionLogger logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (System.Exception ex)
        {
              _logger.Log(ex);

            httpContext.Response.ContentType = "application/json";
            object response = null;
            var statusCode = StatusCodes.Status500InternalServerError;

            if (ex is ForbiddenUseCaseExecutionException)
            {
                statusCode = StatusCodes.Status403Forbidden;
            }

            if (ex is EntityNotFoundException)
            {
                statusCode = StatusCodes.Status404NotFound;
            }

            if (ex is ValidationException e)
            {
                statusCode = StatusCodes.Status422UnprocessableEntity;
                response = new
                {
                    errors = e.Errors.Select(x => new
                    {
                        name = x.PropertyName,
                        error = x.ErrorMessage
                    })
                };
            }

            if (ex is UseCaseConflictException conflictEx)
            {
                statusCode = StatusCodes.Status409Conflict;
                response = new { message = conflictEx.Message };
            }


            httpContext.Response.StatusCode = statusCode;
            if (response != null)
            {
                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
}
