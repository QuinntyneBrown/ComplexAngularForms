using ComplexAngularForms.Api.DomainEvents;
using System;

namespace ComplexAngularForms.Api.Models
{
    public class Mother: Parent
    {
        public Guid MotherId { get; set; }
        public string MaidenName { get; set; }

        public Mother(CreateMother @event)
            :base(@event)
        {

        }

        private Mother()
        {

        }
    }
}
