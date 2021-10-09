using ComplexAngularForms.Api.DomainEvents;
using System;

namespace ComplexAngularForms.Api.Models
{
    public class Father: Parent
    {
        public Guid FatherId { get; set; }
        public Father(CreateParent @event)
        {
            Apply(@event);
        }

        private Father()
        {

        }

    }
}
