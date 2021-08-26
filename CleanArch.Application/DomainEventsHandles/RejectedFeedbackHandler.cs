using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArch.Domain.Events;
using MediatR;

namespace CleanArch.Application.DomainEventsHandles
{
    public class RejectedFeedbackHandler : INotificationHandler<RejectedFeedbackDomainEvent>
    {
        public Task Handle(RejectedFeedbackDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}