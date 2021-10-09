using ComplexAngularForms.Api.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace ComplexAngularForms.Api.Models
{
    public abstract class Parent: AggregateRoot
    {
        [Key]
        public Guid ParentId { get; protected set; }
        public string Firstname { get; protected set; }
        public string Lastname { get; protected set; }
        public DateTime? DateOfBirth { get; protected set; }

        protected override void EnsureValidState()
        {
            if (string.IsNullOrEmpty(Firstname))
            {
                throw new Exception();
            }

            if (string.IsNullOrEmpty(Lastname))
            {
                throw new Exception();
            }

            if (DateOfBirth == default)
            {
                throw new Exception();
            }
        }

    }
}
