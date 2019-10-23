using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAnalyzer.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
