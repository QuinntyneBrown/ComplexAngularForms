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
                ParentId = mother.ParentId,
                Firstname = mother.Firstname,
                Lastname = mother.Lastname,
                DateOfBirth = mother.DateOfBirth,
                MaidenName = mother.MaidenName
            };
        }
        
    }
}
