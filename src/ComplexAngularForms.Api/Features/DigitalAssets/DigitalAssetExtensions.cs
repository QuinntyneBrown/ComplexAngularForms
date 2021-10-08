using System;
using ComplexAngularForms.Api.Models;

namespace ComplexAngularForms.Api.Features
{
    public static class DigitalAssetExtensions
    {
        public static DigitalAssetDto ToDto(this DigitalAsset digitalAsset)
        {
            return new ()
            {
                DigitalAssetId = digitalAsset.DigitalAssetId
            };
        }
        
    }
}
