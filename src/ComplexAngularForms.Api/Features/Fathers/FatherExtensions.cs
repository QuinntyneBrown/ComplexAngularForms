using System;
using ComplexAngularForms.Api.Models;

namespace ComplexAngularForms.Api.Features
{
    public static class FatherExtensions
    {
        public static FatherDto ToDto(this Father father)
        {
            return new ()
            {
                FatherId = father.FatherId
            };
        }
        
    }
}
