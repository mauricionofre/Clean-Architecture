using CleanArch.Application.Features.Feedbacks;
using CleanArch.Application.InputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Api.Controllers.Feedbacks
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly ILogger<FeedbackController> _logger;
        private readonly IFeedbackService _service;

        public FeedbackController(ILogger<FeedbackController> logger, IFeedbackService feedbackService)
        {
            _logger = logger;
            _service = feedbackService;
        }

        public IActionResult FeedbackPost([FromBody] FeedbackInputModel feedback)
        {
            _logger.LogInformation("Adicionando novo Feedback");

            _service.AddAsync(feedback);

            return Ok();
        }
    }
}