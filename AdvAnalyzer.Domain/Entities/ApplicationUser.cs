using AdvAnalyzer.Domain.ValueObjects;
using System;

namespace AdvAnalyzer.Domain.Entities
{
    public class ApplicationUser : AggregateRoot
    {
        public ApplicationUser(Guid id, string email, string phoneNumber) : base(id)
        {
            Email = new Email(email);
            PhoneNumber = new PhoneNumber(phoneNumber);
        }

        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
    }
}
