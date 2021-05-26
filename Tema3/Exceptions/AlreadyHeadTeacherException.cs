using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Exceptions
{
    public class AlreadyHeadTeacherException : Exception
    {
        public AlreadyHeadTeacherException(String exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}
