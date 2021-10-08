using System;
using ComplexAngularForms.Api.Models;

namespace ComplexAngularForms.Api.Features
{
    public static class MotherExtensions
    {
        public static MotherDto ToDto(this Mother mother)
        {
            return new ()
            {
                MotherId = mother.MotherId
            };
        }
        
    }
}
