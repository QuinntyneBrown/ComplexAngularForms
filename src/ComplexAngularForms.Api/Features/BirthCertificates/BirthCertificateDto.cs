using System;

namespace ComplexAngularForms.Api.Features
{
    public class BirthCertificateDto
    {
        public Guid? BirthCertificateId { get; set; }
        public Guid? PhotoDigitalAssetId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid? FatherId { get; set; }
        public Guid? MotherId { get; set; }
        public FatherDto Father { get; set; }
        public MotherDto Mother { get; set; }

        public BirthCertificateDto()
        {

        }
    }
}
