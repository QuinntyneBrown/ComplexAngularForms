using System;

namespace ComplexAngularForms.Api.Models
{
    public class BirthCertificate
    {
        public Guid BirthCertificateId { get; private set; }
        public Guid PhotoDigitalAssetId { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Email { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Father Father { get; private set; }
        public Mother Mother { get; private set; }

        public BirthCertificate()
        {

        }

        private BirthCertificate()
        {

        }
    }
}
