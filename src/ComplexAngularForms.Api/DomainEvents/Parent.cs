using ComplexAngularForms.Api.Core;
using System;

namespace ComplexAngularForms.Api.DomainEvents
{
    public class CreateParent: BaseDomainEvent
    {
        public Guid ParentId { get; private set; } = Guid.NewGuid();
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public CreateParent(
            string firstname,
            string lastname,
            DateTime dateOfBirth)
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
        }
    }

    public class CreateMother: CreateParent
    {
        public string MaidenName { get; set; }

        public CreateMother(string firstname, string lastname, DateTime dateOfBirth, string maidenName)
            :base(firstname,lastname,dateOfBirth)
        {
            MaidenName = maidenName;
        }
    }
}
