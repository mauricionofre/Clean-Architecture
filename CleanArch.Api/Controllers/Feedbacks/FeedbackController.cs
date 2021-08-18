using CleanArch.Application.Features.Feedbacks;
using CleanArch.Application.InputModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        [HttpPost("{id:long}/approve")]
        public async Task<IActionResult> PostApprove([FromBody] FeedbackApproveModel feedback, long id)
        {
            _logger.LogInformation("Aprovando Feedback");

            return HandleService(await _service.ApproveAsync(feedback, id));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return HandleService(await _service.GetAll());
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return HandleService(await _service.GetByIdAsync(id));
        }
    }
}