using CleanArch.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace CleanArch.Api.Controllers
{
    [ApiController]
    public class ApiControllerBase<TSource> : ControllerBase
    {
        public readonly ILogger<TSource> _logger;

        public ApiControllerBase(ILogger<TSource> logger)
        {
            _logger = logger;
        }

        protected IActionResult HandleFailure<T>(T exceptionToHandle) where T : Exception
        {
            return StatusCode((int)HttpStatusCode.BadRequest, exceptionToHandle.Message);
        }

        protected IActionResult HandleService<TFailure, TSuccess>
            (Result<TFailure, TSuccess> result) where TFailure : Exception
        {
            return result.IsFailure ? HandleFailure(result.Failure) : Ok(result.Success);
        }
    }
}