using System;
using ComplexAngularForms.Api.Models;

namespace ComplexAngularForms.Api.Features
{
    public static class BirthCertificateExtensions
    {
        public static BirthCertificateDto ToDto(this BirthCertificate birthCertificate)
        {
            return new ()
            {
                BirthCertificateId = birthCertificate.BirthCertificateId
            };
        }
        
    }
}
