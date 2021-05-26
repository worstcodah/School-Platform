using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Exceptions
{
    public class NonExistentStudentException : Exception
    {
        public NonExistentStudentException(String exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}
