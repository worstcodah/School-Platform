using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Exceptions
{
    public class NonExistentTeacherException : Exception
    {
        public NonExistentTeacherException(String exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}
