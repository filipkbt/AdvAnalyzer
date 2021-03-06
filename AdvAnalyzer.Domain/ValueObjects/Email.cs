using AdvAnalyzer.Domain.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvAnalyzer.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string value)
        {
            if (string.IsNullOrEmpty(value) || !IsValidEmail(value))
            {
                throw new DomainException("Email is invalid");
            }

            Value = value;
        }

        private Email()
        {
        }

        public string Value { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        private bool IsValidEmail(string value)
        {
            return new EmailAddressAttribute().IsValid(value);
        }
    }
}
