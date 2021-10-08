using System;

namespace ComplexAngularForms.Api.Models
{
    public class Parent
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public Parent()
        {

        }

        private Parent()
        {

        }
    }
}
