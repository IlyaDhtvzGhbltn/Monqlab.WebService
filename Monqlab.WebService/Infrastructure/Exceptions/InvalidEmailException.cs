using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Infrastructure
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException() : base() { }

        public InvalidEmailException(string message) : base(message) { }

        public InvalidEmailException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
