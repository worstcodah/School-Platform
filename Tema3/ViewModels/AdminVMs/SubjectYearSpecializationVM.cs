using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Commands;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class SubjectYearSpecializationVM : BaseVM
    {
        private ObservableCollection<Subject> _subjectCollection;
        public ObservableCollection<Subject> SubjectCollection
        {
            get
            {
                return _subjectCollection;
            }
            set
            {
                _subjectCollection = value;
                OnPropertyChanged(nameof(SubjectCollection));
            }
        }
        private SubjectDAL _subjectDAL { get; set; }
        private ObservableCollection<Year> _yearCollection;
        public ObservableCollection<Year> YearCollection
        {
            get
            {
                return _yearCollection;
            }
            set
            {
                _yearCollection = value;
                OnPropertyChanged(nameof(YearCollection));
            }
        }
        private YearDAL _yearDAL { get; set; }
        private ObservableCollection<Specialization> _specializationCollection;
        public ObservableCollection<Specialization> SpecializationCollection
        {
            get
            {
                return _specializationCollection;
            }
            set
            {
                _specializationCollection = value;
                OnPropertyChanged(nameof(SpecializationCollection));
            }
        }
        private SpecializationDAL _specializationDAL { get; set; }
        private Subject _selectedSubject;
        public Subject SelectedSubject
        {
            get
            {
                return _selectedSubject;
            }
            set
            {
                _selectedSubject = value;
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }
        private Year _selectedYear;
        public Year SelectedYear
        {
            get
            {
                return _selectedYear;
            }
            set
            {
                _selectedYear = value;
                OnPropertyChanged(nameof(SelectedYear));
            }
        }
        private Specialization _selectedSpecialization;
        public Specialization SelectedSpecialization
        {
            get
            {
                return _selectedSpecialization;
            }
            set
            {
                _selectedSpecialization = value;
                OnPropertyChanged(nameof(SelectedSpecialization));
            }
        }
        private ObservableCollection<SubjectYearSpecialization> _subjectYearSpecializationCollection;
        public ObservableCollection<SubjectYearSpecialization> SubjectYearSpecializationCollection
        {
            get
            {
                return _subjectYearSpecializationCollection;
            }
            set
            {
                _subjectYearSpecializationCollection = value;
                OnPropertyChanged(nameof(SubjectYearSpecializationCollection));
            }
        }
        private Semester _selectedSemester;
        public Semester SelectedSemester
        {
            get
            {
                return _selectedSemester;
            }
            set
            {
                _selectedSemester = value;
                OnPropertyChanged(nameof(SelectedSemester));
            }
        }
        private List<Semester> _semesterCollection;
        public List<Semester> SemesterCollection
        {
            get
            {
                return _semesterCollection;
            }
            set
            {
                _semesterCollection = value;
                OnPropertyChanged(nameof(SemesterCollection));
            }
        }
        private String _selectedThesisChoice;
        public String SelectedThesisChoice
        {
            get
            {
                return _selectedThesisChoice;
            }
            set
            {
                _selectedThesisChoice = value;
                OnPropertyChanged(nameof(SelectedThesisChoice));
            }
        }
        private List<String> _thesisChoices;
        public List<String> ThesisChoices
        {
            get
            {
                return _thesisChoices;
            }
            set
            {
                _thesisChoices = value;
                OnPropertyChanged(nameof(ThesisChoices));
            }
        }
        private SubjectYearSpecializationServices _subjectYearSpecializationServices { get; set; }
        public RelayCommand LinkFieldsCommand { get; set; }
        public SubjectYearSpecializationVM()
        {
            SubjectYearSpecializationCollection = new ObservableCollection<SubjectYearSpecialization>();
            _subjectYearSpecializationServices = new SubjectYearSpecializationServices(this);
            LinkFieldsCommand = new RelayCommand(_subjectYearSpecializationServices.LinkTogether, _subjectYearSpecializationServices.CanLink);
            _subjectYearSpecializationServices.InitializeCollections();
        }
    }
}
