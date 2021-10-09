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

    public class CreateFather: CreateParent
    {
        public CreateFather(string firstname, string lastname, DateTime dateOfBirth)
            :base(firstname, lastname, dateOfBirth)
        {

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

    public class CreateParents: BaseDomainEvent
    {
        public string MotherFirstname { get; private set; }
        public string MotherLastname { get; private set; }
        public DateTime MotherDateOfBirth { get; private set; }
        public string MotherMaidenName { get; private set; }
        public string FatherFirstname { get; private set; }
        public string FatherLastname { get; private set; }
        public DateTime FatherDateOfBirth { get; private set; }

        public CreateParents(
            string motherFirstname,
            string motherLastname,
            DateTime motherDateOfBirth,
            string motherMaidenName,
            string fatherFirstname,
            string fatherLastname,
            DateTime fatherDateOfBirth)
        {
            MotherFirstname = motherFirstname;
            MotherLastname = motherLastname;
            MotherDateOfBirth = motherDateOfBirth;
            MotherMaidenName = motherMaidenName;
            FatherFirstname = fatherFirstname;
            FatherLastname = fatherLastname;
            FatherDateOfBirth = fatherDateOfBirth;
        }
    }

    public class CreatedParents: BaseDomainEvent
    {
        public Guid? MotherId { get; set; }
        public Guid? FatherId { get; set; }

        public CreatedParents(Guid? motherId, Guid? fatherId)
        {
            MotherId = motherId;
            FatherId = fatherId;
        }
    }

    public class CreatedParent : BaseDomainEvent
    {
        public Guid? ParentId { get; private set; }

        public CreatedParent(Guid? parentId)
        {
            ParentId = parentId;
        }
    }

    public class CreatedMother: CreatedParent
    {
        public CreatedMother(Guid? parentId)
            :base(parentId)
        {

        }
    }

    public class CreatedFather : CreatedParent
    {
        public CreatedFather(Guid? parentId)
            : base(parentId)
        {

        }
    }
}
