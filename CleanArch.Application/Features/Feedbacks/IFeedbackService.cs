using CleanArch.Application.InputModels;
using CleanArch.Domain;
using System;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Feedbacks
{
    public interface IFeedbackService
    {
        Task<Result<Exception, Unit>> AddAsync(FeedbackInputModel inputModel);
    }
}