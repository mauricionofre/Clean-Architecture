using CleanArch.Application.Features.Users;
using CleanArch.Application.InputModels;
using CleanArch.Domain;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Notifications;
using CleanArch.Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Feedbacks
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUserService _userService;
        private readonly IFeedbackRepository _repository;
        private readonly IFeedbackNotification _feedbackCreated;

        public FeedbackService(
            IUserService userService,
            IFeedbackRepository repository,
            IFeedbackNotification feedbackCreated)
        {
            _userService = userService;
            _repository = repository;
            _feedbackCreated = feedbackCreated;
        }

        public async Task<Result<Exception, FeedbackOutputModel>> AddAsync(FeedbackInputModel inputModel)
        {
            User toUser = _userService.GetById(inputModel.ToUser);
            User fromUser = _userService.GetById(inputModel.FromUser);

            if (toUser == null || fromUser == null)
                return new Exception("Não foi possivel encontrar os usuários");

            Feedback feedback = new Feedback
            {
                Commentary = inputModel.Commentary,
                ToUserId = toUser.Id,
                FromUserId = fromUser.Id
            };

            var addResult = await _repository.AddAsync(feedback);
            if (addResult.IsFailure)
                return new Exception("Não Foi possivel adicionar o Feedback");

            _ = _feedbackCreated.CreatedFeedbackAsync(feedback);

            return new FeedbackOutputModel(feedback);
        }

        public async Task<Result<Exception, IQueryable<FeedbackOutputModel>>> GetAll()
        {
            var getAllResult = await _repository.GetAll();
            if (getAllResult.IsFailure)
                return new Exception("Não foi possivel retornar os Feedbacks");

            var feedbacks = getAllResult.Success
                .Select(f => new FeedbackOutputModel
                {
                    Id = f.Id,
                    Commentary = f.Commentary,
                    FromUserId = f.FromUserId,
                    ToUserId = f.ToUserId
                });

            return Result.Run(() => feedbacks);
        }
    }
}