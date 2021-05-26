using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class GradeCollectionItem : TableInfo
    {
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
        public GradeCollectionItem(int idStudent, int idSubject, int idYear, int idClass, int idSpecialization, String studentName, String subjectName, String yearName, String className,
            String specializationName, int gradeValue, bool isThesisGrade, int idSemester, String date): base( idStudent,  idSubject,  idYear,  idClass, idSpecialization,  studentName,  subjectName,  
                yearName, className, specializationName )
        {
            GradeValue = gradeValue;
            IsThesisGrade = isThesisGrade;
            IdSemester = idSemester;
            Date = date;
        }
        public GradeCollectionItem() : base()
        {

        }
    }
}
