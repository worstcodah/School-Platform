using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class Absentee : BasePropertyChanged
    {
        private int _idStudent;
        public int IdStudent
        {
            get
            {
                return _idStudent;
            }
            set
            {
                _idStudent = value;
                OnPropertyChanged(nameof(IdStudent));
            }
        }
        private int _idTeacherSubjectClass;
        public int IdTeacherSubjectClass
        {
            get
            {
                return _idTeacherSubjectClass;
            }
            set
            {
                _idTeacherSubjectClass = value;
                OnPropertyChanged(nameof(IdTeacherSubjectClass));
            }
        }
        private bool _isMotivated;
        public bool IsMotivated
        {
            get
            {
                return _isMotivated;
            }
            set
            {
                _isMotivated = value;
                OnPropertyChanged(nameof(IsMotivated));
            }
        }
        private String _date;
        public String Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        private int _idSemester;
        public int IdSemester
        {
            get
            {
                return _idSemester;
            }
            set
            {
                _idSemester = value;
                OnPropertyChanged(nameof(IdSemester));
            }
        }
        public Absentee(int idStudent, int idTeacherSubjectClass, bool isMotivated, String date, int idSemester)
        {
            IdStudent = idStudent;
            IdTeacherSubjectClass = idTeacherSubjectClass;
            IsMotivated = isMotivated;
            Date = date;
            IdSemester = idSemester;
        }
    }
}
