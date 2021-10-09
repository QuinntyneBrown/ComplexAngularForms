using ComplexAngularForms.Api.Core;
using System;

namespace ComplexAngularForms.Api.DomainEvents
{
    public class CreateBirthCertificate: BaseDomainEvent
    {
        public Guid BirthCertificateId { get; private set; } = Guid.NewGuid();
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Email { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Guid? FatherId { get; private set; }
        public Guid? MotherId { get; private set; }

        public CreateBirthCertificate(
            string firstname,
            string lastname,
            string email,
            string city,
            string province,
            DateTime dateOfBirth,
            Guid? fatherId,
            Guid? motherId)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            City = city;
            Province = province;
            DateOfBirth = dateOfBirth;
            FatherId = fatherId;
            MotherId = motherId;
        }
    }

    public class UpdatePhoto: BaseDomainEvent
    {
        public Guid PhotoDigitalAssetId { get; private set; }
        public UpdatePhoto(Guid photoDigitalAssetId)
        {
            PhotoDigitalAssetId = photoDigitalAssetId;
        }
    }
}
