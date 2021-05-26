using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Commands;
using Tema3.Models.EntityLayer;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class TeacherMenuMeanVM : BaseVM
    {
        private SubjectYearSpecialization _selectedSubjectYearSpecialization;
        public SubjectYearSpecialization SelectedSubjectYearSpecialization
        {
            get
            {
                return _selectedSubjectYearSpecialization;
            }
            set
            {
                _selectedSubjectYearSpecialization = value;
                OnPropertyChanged(nameof(SelectedSubjectYearSpecialization));
                _teacherMenuMeanServices.GetSpecificStudents();
            }
        }
        private int _loggedTeacherId;
        public int LoggedTeacherId
        {
            get
            {
                return _loggedTeacherId;
            }
            set
            {
                _loggedTeacherId = value;
                OnPropertyChanged(nameof(LoggedTeacherId));
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
        private ObservableCollection<StudentFinalGrade> _studentFinalGradeCollection;
        public ObservableCollection<StudentFinalGrade> StudentFinalGradeCollection
        {
            get
            {
                return _studentFinalGradeCollection;
            }
            set
            {
                _studentFinalGradeCollection = value;
                OnPropertyChanged(nameof(StudentFinalGradeCollection));
            }
        }
        public RelayCommand CalculateMeanCommand { get; set; }
        private TeacherMenuMeanServices _teacherMenuMeanServices { get; set; }
        public TeacherMenuMeanVM(int loggedTeacherId)
        {
            _teacherMenuMeanServices = new TeacherMenuMeanServices(this);
            LoggedTeacherId = loggedTeacherId;
            _teacherMenuMeanServices.InitializeFields();

        }
    }
}
