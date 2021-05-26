using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Exceptions
{
    public class ExistentAbsenteeException : Exception
    {
        public ExistentAbsenteeException(String exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}
