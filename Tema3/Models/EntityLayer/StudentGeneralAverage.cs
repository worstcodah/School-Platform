using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class StudentGeneralAverage : Student
    {
        private int _generalAverage;
        public int GeneralAverage
        {
            get
            {
                return _generalAverage;
            }
            set
            {
                _generalAverage = value;
                OnPropertyChanged(nameof(GeneralAverage));
            }
        }
    }
}
