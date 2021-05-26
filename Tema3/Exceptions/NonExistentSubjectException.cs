using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Exceptions
{
    public class NonExistentSubjectException : Exception
    {
        public NonExistentSubjectException(String exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}
