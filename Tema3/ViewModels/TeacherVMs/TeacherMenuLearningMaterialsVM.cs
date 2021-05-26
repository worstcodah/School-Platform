using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Commands;
using Tema3.Models.EntityLayer;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class TeacherMenuLearningMaterialsVM : BaseVM
    {
        private ObservableCollection<LearningMaterial> _learningMaterialCollection;
        public ObservableCollection<LearningMaterial> LearningMaterialCollection
        {
            get
            {
                return _learningMaterialCollection;
            }
            set
            {
                _learningMaterialCollection = value;
                OnPropertyChanged(nameof(LearningMaterialCollection));
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
                _teacherMenuLearningMaterialsServices.GetSpecificLearningMaterials();
            }
        }
        private String _selectedFilePath;
        public String SelectedFilePath
        {
            get
            {
                return _selectedFilePath;
            }
            set
            {
                _selectedFilePath = value;
                OnPropertyChanged(nameof(SelectedFilePath));
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
        public RelayCommand AddLearningMaterialCommand { get; set; }
        public RelayCommand SelectLearningMaterialPathCommand { get; set; }
        public RelayCommand DeleteSelectedLearningMaterialsCommand { get; set; }
        private TeacherMenuLearningMaterialsServices _teacherMenuLearningMaterialsServices { get; set; }
        public TeacherMenuLearningMaterialsVM(int loggedTeacherId)
        {
            _teacherMenuLearningMaterialsServices = new TeacherMenuLearningMaterialsServices(this);
            this.LoggedTeacherId = loggedTeacherId;
            _teacherMenuLearningMaterialsServices.InitializeFields();
        }
    }
}
