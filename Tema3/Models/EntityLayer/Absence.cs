using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class Absence : TableInfo
    {

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
        public Absence(int idStudent, String studentName, int idClass, String className, int idSpecialization, String specializationName,
            int idYear, String yearName, int idSubject, String subjectName, bool isMotivated, String date, int idSemester)
        {
            IdClass = idClass;
            ClassName = className;
            IdSpecialization = idSpecialization;
            SpecializationName = specializationName;
            IdYear = idYear;
            YearName = yearName;
            IdStudent = idStudent;
            StudentName = studentName;
            IdSubject = idSubject;
            SubjectName = subjectName;
            IsMotivated = isMotivated;
            Date = date;
            IdSemester = idSemester;
        }
        public Absence()
        {

        }
    }
}
