using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class SubjectFinalGrade : Subject
    {
        private int _finalGrade;
        public int FinalGrade
        {
            get
            {
                return _finalGrade;
            }
            set
            {
                _finalGrade = value;
                OnPropertyChanged(nameof(FinalGrade));
            }
        }
    }
}
