using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.DomainEvents;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplexAngularForms.Api.Models
{
    public class BirthCertificate: AggregateRoot
    {
        public Guid BirthCertificateId { get; private set; }
        public Guid PhotoDigitalAssetId { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Email { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        [ForeignKey("Father")]
        public Guid? FatherId { get; private set; }
        [ForeignKey("Mother")]
        public Guid? MotherId { get; set; }
        public Father Father { get; private set; }
        public Mother Mother { get; private set; }

        public BirthCertificate(CreateBirthCertificate @event)
        {
            Apply(@event);
        }

        private BirthCertificate()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateBirthCertificate @event)
        {
            BirthCertificateId = @event.BirthCertificateId;
            Firstname = @event.Firstname;
            Lastname = @event.Lastname;
            Email = @event.Email;
            DateOfBirth = @event.DateOfBirth;
            City = @event.City;
            Province = @event.Province;
            MotherId = @event.MotherId;
            FatherId = @event.FatherId;
        }

        protected override void EnsureValidState()
        {

        }
    }
}
