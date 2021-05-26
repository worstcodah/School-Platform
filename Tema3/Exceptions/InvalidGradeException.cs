using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Exceptions
{
    public class InvalidGradeException : Exception
    {
        public InvalidGradeException(String exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}
