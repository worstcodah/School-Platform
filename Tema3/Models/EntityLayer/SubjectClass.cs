using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class SubjectClass : BasePropertyChanged
    {

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
        private int _idYear;
        public int IdYear
        {
            get
            {
                return _idYear;
            }
            set
            {
                _idYear = value;
                OnPropertyChanged(nameof(IdYear));
            }
        }
        private int _idClass;
        public int IdClass
        {
            get
            {
                return _idClass;
            }
            set
            {
                _idClass = value;
                OnPropertyChanged(nameof(IdClass));
            }
        }
        private int _idSpecialization;
        public int IdSpecialization
        {
            get
            {
                return _idSpecialization;
            }
            set
            {
                _idSpecialization = value;
                OnPropertyChanged(nameof(IdSpecialization));
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
        private String _className;
        public String ClassName
        {
            get
            {
                return _className;
            }
            set
            {
                _className = value;
                OnPropertyChanged(nameof(ClassName));
            }
        }
        private String _specializationName;
        public String SpecializationName
        {
            get
            {
                return _specializationName;
            }
            set
            {
                _specializationName = value;
                OnPropertyChanged(nameof(SpecializationName));
            }
        }
        private String _yearName;
        public String YearName
        {
            get
            {
                return _yearName;
            }
            set
            {
                _yearName = value;
                OnPropertyChanged(nameof(YearName));
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
        public override string ToString()
        {
            return SubjectName + " " + ClassName + " " + SpecializationName + " " + YearName + " " + SemesterName;
        }

    }
}
