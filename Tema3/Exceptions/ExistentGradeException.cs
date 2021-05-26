using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Exceptions
{
    public class ExistentGradeException : Exception
    {
        public ExistentGradeException(String exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}
