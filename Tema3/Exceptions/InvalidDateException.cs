using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Exceptions
{
    public class InvalidDateException : Exception
    {
        public InvalidDateException(String exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}
