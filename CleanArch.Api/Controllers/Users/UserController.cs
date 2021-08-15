using CleanArch.Application.Features.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Api.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _service = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Buscando Usuarios");

            var users = _service.GetAll();
            return Ok(users);
        }
    }
}