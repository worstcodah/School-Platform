using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class TableInfo : BasePropertyChanged
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
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
        public TableInfo(int idStudent, int idSubject, int idYear, int idClass, int idSpecialization, String studentName, String subjectName, String yearName, String className,
            String specializationName)
        {
            IdStudent = idStudent;
            IdSubject = idSubject;
            IdYear = idYear;
            IdClass = idClass;
            IdSpecialization = idSpecialization;
            StudentName = studentName;
            SubjectName = subjectName;
            YearName = yearName;
            ClassName = className;
            SpecializationName = specializationName;
        }
        public TableInfo()
        {

        }
    }
}
