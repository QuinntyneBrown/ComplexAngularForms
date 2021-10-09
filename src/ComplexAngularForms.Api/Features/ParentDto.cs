using System;

namespace ComplexAngularForms.Api.Features
{
    public class ParentDto
    {
        public Guid ParentId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
