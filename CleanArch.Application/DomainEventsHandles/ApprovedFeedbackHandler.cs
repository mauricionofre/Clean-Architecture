using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArch.Domain.Events;
using MediatR;

namespace CleanArch.Application.DomainEventsHandles
{
    public class ApprovedFeedbackHandler : INotificationHandler<ApprovedFeedbackDomainEvent>
    {
        public Task Handle(ApprovedFeedbackDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}