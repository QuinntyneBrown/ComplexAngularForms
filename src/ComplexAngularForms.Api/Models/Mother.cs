using System;

namespace ComplexAngularForms.Api.Models
{
    public class Mother: Parent
    {
        public Guid MotherId { get; set; }
        public string MaidenName { get; set; }
    }
}
