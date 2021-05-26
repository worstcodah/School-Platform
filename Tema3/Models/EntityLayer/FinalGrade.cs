using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class FinalGrade : BasePropertyChanged
    {
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
        private String _semesterName;
        public String SemesterName
        {
            get
            {
                return _semesterName;
            }
            set
            {
                _semesterName = value;
                OnPropertyChanged(nameof(SemesterName));
            }
        }
    }
}
