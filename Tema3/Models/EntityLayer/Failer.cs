using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class Failer : BasePropertyChanged
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
        private String _studentName;
        public String StudentName
        {
            get
            {
                return _studentName;
            }
            set
            {
                _studentName = value;
                OnPropertyChanged(nameof(StudentName));
            }
        }
        private int _idSubject;
        public int IdSubject
        {
            get
            {
                return _idSubject;
            }
            set
            {
                _idSubject = value;
                OnPropertyChanged(nameof(IdSubject));
            }
        }
        private String _subjectName;
        public String SubjectName
        {
            get
            {
                return _subjectName;
            }
            set
            {
                _subjectName = value;
                OnPropertyChanged(nameof(SubjectName));
            }
        }
        private int _finalGradeValue;
        public int FinalGradeValue
        {
            get
            {
                return _finalGradeValue;
            }
            set
            {
                _finalGradeValue = value;
                OnPropertyChanged(nameof(FinalGradeValue));
            }
        }
    }
}
