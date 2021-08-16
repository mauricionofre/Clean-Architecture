using CleanArch.Application.InputModels;
using CleanArch.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Feedbacks
{
    public interface IFeedbackService
    {
        Task<Result<Exception, FeedbackOutputModel>> AddAsync(FeedbackInputModel inputModel);

        Task<Result<Exception, IQueryable<FeedbackOutputModel>>> GetAll();
    }
}