using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Exceptions
{
    public class ExistentSubjectException : Exception
    {
        public ExistentSubjectException(String exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}
