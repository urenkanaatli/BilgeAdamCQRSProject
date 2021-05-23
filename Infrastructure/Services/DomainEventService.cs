using Application.Interfaces;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Infrastructure.Services
{
    public class DomainEventService : IDomainEventService
    {
        private readonly IPublisher publisher;

        public DomainEventService(IPublisher publisher)
        {
            this.publisher = publisher;
        }
        public async Task Publish(DomainEvent domainEvent)
        {
            await publisher.Publish(domainEvent);
        }
    }
}
