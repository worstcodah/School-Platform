using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Exceptions
{
    public class ExistentLearningMaterialException : Exception
    {
        public ExistentLearningMaterialException(String exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}
