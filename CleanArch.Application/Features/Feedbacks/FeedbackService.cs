using CleanArch.Application.Features.Users;
using CleanArch.Application.InputModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Features.Feedbacks
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUserService _userService;
        private readonly IFeedbackRepository _repository;

        public FeedbackService(IUserService userService, IFeedbackRepository repository)
        {
            _userService = userService;
            _repository = repository;
        }

        public void Add(FeedbackInputModel inputModel)
        {
            User toUser = _userService.GetById(inputModel.ToUser);
            User fromUser = _userService.GetById(inputModel.FromUser);

            if (toUser == null || fromUser == null)
                return;

            Feedback feedback = new Feedback
            {
                Commentary = inputModel.Commentary,
                ToUser = toUser,
                FromUser = fromUser
            };

            _repository.Add(feedback);
        }
    }
}