using CleanArch.Application.Features.Users;
using CleanArch.Application.InputModels;
using CleanArch.Domain;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Notifications;
using CleanArch.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<Result<Exception, Unit>> AddAsync(FeedbackInputModel inputModel)
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

            return Unit.Successful;
        }
    }
}