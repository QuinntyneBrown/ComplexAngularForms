using ComplexAngularForms.Api.Models;

namespace ComplexAngularForms.Api.Features
{
    public static class BirthCertificateExtensions
    {
        public static BirthCertificateDto ToDto(this BirthCertificate birthCertificate)
        {
            return new ()
            {
                BirthCertificateId = birthCertificate.BirthCertificateId,
                PhotoDigitalAssetId = birthCertificate.PhotoDigitalAssetId,
                Firstname = birthCertificate.Firstname,
                Lastname = birthCertificate.Lastname,
                Email = birthCertificate.Email,
                City = birthCertificate.City,
                Province = birthCertificate.Province,
                DateOfBirth = birthCertificate.DateOfBirth,
                FatherId = birthCertificate.FatherId,
                MotherId = birthCertificate.MotherId
            };
        }        
    }
}
