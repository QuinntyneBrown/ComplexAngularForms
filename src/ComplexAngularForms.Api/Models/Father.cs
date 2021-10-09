using ComplexAngularForms.Api.DomainEvents;
using System;

namespace ComplexAngularForms.Api.Models
{
    public class Father: Parent
    {
        public Father(CreateParent @event)
        {
            Apply(@event);
        }

        private Father()
        {

        }

    }
}
