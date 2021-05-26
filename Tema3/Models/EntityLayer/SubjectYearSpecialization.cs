using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    //Entity obtained by joining Subject, Year & Class
    public class SubjectYearSpecialization : BasePropertyChanged
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
        private bool _isThesis;
        public bool IsThesis
        {
            get
            {
                return _isThesis;
            }
            set
            {
                _isThesis = value;
                OnPropertyChanged(nameof(IsThesis));
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
        public override string ToString()
        {
            return SubjectName + " " + SpecializationName + " " + YearName + " " + SemesterName;
        }
        public SubjectYearSpecialization()
        {

        }
        public SubjectYearSpecialization(Subject subject, Year year, Specialization specialization, bool isThesis, int idSemester,
            String semesterName)
        {
            this.IdSubject = subject.Id;
            this.IdYear = year.Id;
            this.IdSpecialization = specialization.Id;
            this.SubjectName = subject.Name;
            this.YearName = year.Name;
            this.SpecializationName = specialization.Name;
            this.IsThesis = isThesis;
            this.IdSemester = idSemester;
            this.SemesterName = semesterName;
        }
    }
}
