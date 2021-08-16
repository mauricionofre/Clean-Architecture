using CleanArch.Application.Features.Feedbacks;
using CleanArch.Application.InputModels;
using CleanArch.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CleanArch.Api.Controllers.Feedbacks
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ApiControllerBase<FeedbackController>
    {
        private readonly IFeedbackService _service;

        public FeedbackController(ILogger<FeedbackController> logger, IFeedbackService feedbackService) : base(logger)
        {
            _service = feedbackService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FeedbackInputModel feedback)
        {
            _logger.LogInformation("Adicionando novo Feedback");

            return HandleService(await _service.AddAsync(feedback));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return HandleService(await _service.GetAll());
        }
    }
}