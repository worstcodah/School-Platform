using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Exceptions
{
    public class ExistentStudentException : Exception
    {
        public ExistentStudentException(String exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}
