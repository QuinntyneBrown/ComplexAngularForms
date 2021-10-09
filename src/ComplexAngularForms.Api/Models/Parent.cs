using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.DomainEvents;
using System;

namespace ComplexAngularForms.Api.Models
{
    public class Parent: AggregateRoot
    {
        public Guid ParentId { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public Parent(CreateParent @event)
        {
            Apply(@event);
        }

        protected Parent()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateParent @event)
        {
            ParentId = @event.ParentId;
        }
        protected override void EnsureValidState()
        {

        }
    }
}
