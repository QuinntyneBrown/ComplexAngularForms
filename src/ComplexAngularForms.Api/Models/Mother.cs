using ComplexAngularForms.Api.DomainEvents;

namespace ComplexAngularForms.Api.Models
{
    public class Mother: Parent
    {
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
