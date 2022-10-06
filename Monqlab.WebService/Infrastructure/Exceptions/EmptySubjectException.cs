using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Infrastructure
{
    public class EmptySubjectException : Exception
    {
        public EmptySubjectException() : base() { }

        public EmptySubjectException(string message) : base(message) { }

        public EmptySubjectException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
