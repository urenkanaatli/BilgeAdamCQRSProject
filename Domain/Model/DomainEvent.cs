using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public interface IHaveDomainEvent
    {

        public List<DomainEvent> DomainEvents { get; set; }
    }

    public class DomainEvent : INotification
    {
        public DomainEvent()
        {
            Date = DateTime.Now;
        }

        public bool IsPublished { get; set; }

        public DateTime Date { get; set; }

    }
}
