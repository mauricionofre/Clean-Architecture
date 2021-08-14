using CleanArch.Application.InputModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Features.Feedbacks
{
    public interface IFeedbackService
    {
        void Add(FeedbackInputModel inputModel);
    }
}