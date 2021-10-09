using ComplexAngularForms.Api.DomainEvents;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplexAngularForms.Api.Models
{
    public class Mother: Parent
    {
        public Guid MotherId => ParentId;
        public string MaidenName { get; set; }

        public Mother(CreateMother @event)
        {
            Apply(@event);
        }

        private Mother()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateMother @event)
        {
            Firstname = @event.Firstname;
            Lastname = @event.Lastname;
            DateOfBirth = @event.DateOfBirth;
            MaidenName = @event.MaidenName;
        }

        protected override void EnsureValidState()
        {
            if(string.IsNullOrEmpty(MaidenName))
            {
                throw new Exception();
            }

            base.EnsureValidState();
        }
    }
}
