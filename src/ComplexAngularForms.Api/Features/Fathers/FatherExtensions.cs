using ComplexAngularForms.Api.Models;

namespace ComplexAngularForms.Api.Features
{
    public static class FatherExtensions
    {
        public static FatherDto ToDto(this Father father)
        {
            return new ()
            {
                ParentId = father.ParentId,
                Firstname = father.Firstname,
                Lastname = father.Lastname,
                DateOfBirth = father.DateOfBirth
            };
        }        
    }
}
