using ComplexAngularForms.Api.DomainEvents;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplexAngularForms.Api.Models
{
    public class Father: Parent
    {
        public Guid FatherId => ParentId;

        public Father(CreateParent @event)
        {
            Apply(@event);
        }

        private Father()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateParent @event)
        {
            Firstname = @event.Firstname;
            Lastname = @event.Lastname;
            DateOfBirth = @event.DateOfBirth;
        }
    }
}
