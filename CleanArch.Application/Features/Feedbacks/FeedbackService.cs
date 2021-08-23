using CleanArch.Application.Features.Users;
using CleanArch.Application.InputModels;
using CleanArch.Domain;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Enums;
using CleanArch.Domain.Notifications;
using CleanArch.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Feedbacks
{
    public class FeedbackService : IFeedbackService
    {
        private readonly ILogger<FeedbackService> _logger;
        private readonly IUserService _userService;
        private readonly IFeedbackRepository _repository;
        private readonly IFeedbackNotification _feedbackNotify;

        public FeedbackService(ILogger<FeedbackService> logger, IUserService userService, IFeedbackRepository repository, IFeedbackNotification feedbackNotify) =>
            (_logger, _userService, _repository, _feedbackNotify) = (logger, userService, repository, feedbackNotify);

        public async Task<Result<Exception, FeedbackOutputModel>> ApproveAsync(FeedbackApproveModel inputModel, int feedbackId)
        {
            if (!inputModel.Approve && string.IsNullOrEmpty(inputModel.DescriptionRejection))
                return new Exception("Descrição da rejeição não está preenchida");

            var getResult = await _repository.GetById(feedbackId);
            if (getResult.IsFailure || getResult.Success == null)
                return new Exception("Não foi possivel retornar o Feedback");

            var feedback = getResult.Success;

            if (inputModel.Approve)
                feedback.Approve();
            else
                feedback.Reject(inputModel.DescriptionRejection);

            var updateResult = await _repository.UnitOfWork.SaveEntitiesAsync();
            if (updateResult.IsFailure)
                return new Exception("Não foi possivel retornar o Feedback");

            _ = _feedbackNotify.ApprovedFeedbackAsync(feedback);

            return new FeedbackOutputModel(feedback);
        }

        public async Task<Result<Exception, FeedbackOutputModel>> AddAsync(FeedbackInputModel inputModel)
        {
            _logger.LogInformation("Adicionando feedback");
            User toUser = _userService.GetById(inputModel.ToUser);
            User fromUser = _userService.GetById(inputModel.FromUser);

            if (toUser == null || fromUser == null)
                return new Exception("Não foi possivel encontrar os usuários");

            _logger.LogDebug("Mapeando feedback");
            Feedback feedback = new Feedback
            {
                Commentary = inputModel.Commentary,
                Status = FeedbackStatusEnum.Pending,
                CreatedAt = DateTime.Now,
                ToUserId = toUser.Id,
                FromUserId = fromUser.Id
            };

            _logger.LogDebug("Adicionando ao repositorio");
            var addResult = _repository.Add(feedback);
            if (addResult.IsFailure)
                return new Exception("Não foi possivel adicionar o Feedback");

            var result = await _repository.UnitOfWork.SaveEntitiesAsync();

            _logger.LogDebug("Criando notificação");
            _ = _feedbackNotify.CreatedFeedbackAsync(feedback);

            _logger.LogInformation("Feedback criado com sucesso");
            return new FeedbackOutputModel(feedback);
        }

        public async Task<Result<Exception, IQueryable<FeedbackOutputModel>>> GetAll()
        {
            var getAllResult = await _repository.GetAll();
            if (getAllResult.IsFailure)
                return new Exception("Não foi possivel retornar os Feedbacks");

            var feedbacks = getAllResult.Success
                .Select(f => new FeedbackOutputModel(f));

            return Result.Run(() => feedbacks);
        }

        public async Task<Result<Exception, FeedbackOutputModel>> GetByIdAsync(int id)
        {
            var getAllResult = await _repository.GetById(id);
            if (getAllResult.IsFailure || getAllResult.Success == null)
                return new Exception("Não foi possivel retornar o Feedback");

            var result = getAllResult.Success;
            var mapped = new FeedbackOutputModel
            {
                Id = result.Id,
                Commentary = result.Commentary,
                FromUserId = result.FromUserId,
                ToUserId = result.ToUserId
            };

            return Result.Run(() => mapped);
        }
    }
}