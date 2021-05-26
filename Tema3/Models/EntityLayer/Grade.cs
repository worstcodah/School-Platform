using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class Grade : BasePropertyChanged
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
        private int _gradeValue;
        public int GradeValue
        {
            get
            {
                return _gradeValue;
            }
            set
            {
                _gradeValue = value;
                OnPropertyChanged(nameof(GradeValue));
            }
        }
        private bool _isThesisGrade;
        public bool IsThesisGrade
        {
            get
            {
                return _isThesisGrade;
            }
            set
            {
                _isThesisGrade = value;
                OnPropertyChanged(nameof(IsThesisGrade));
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
        public Grade()
        {

        }
        public Grade(int gradeValue, int idTeacherSubjectClass)
        {
            this.GradeValue = gradeValue;
            this.IdTeacherSubjectClass = idTeacherSubjectClass;
        }
        public Grade(int idStudent, int idTeacherSubjectClass, int gradeValue, bool isThesisGrade, int idSemester, String date)
        {
            IdStudent = idStudent;
            IdTeacherSubjectClass = idTeacherSubjectClass;
            GradeValue = gradeValue;
            IsThesisGrade = isThesisGrade;
            IdSemester = idSemester;
            Date = date;
        }
    }
}
