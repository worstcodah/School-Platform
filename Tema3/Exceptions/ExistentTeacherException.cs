using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Exceptions
{
    public class ExistentTeacherException : Exception
    {
        public ExistentTeacherException(String exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}
