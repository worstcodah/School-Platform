using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Models.EntityLayer;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class StudentLearningMaterialsVM : BaseVM
    {
        public StudentLearningMaterialsVM(int loggedStudentId)
        {
            this.LoggedStudentId = loggedStudentId;
            _studentLearningMaterialsServices = new StudentLearningMaterialsServices(this);
            _studentLearningMaterialsServices.InitializeFields();
        }
        private StudentLearningMaterialsServices _studentLearningMaterialsServices { get; set; }
        private int _loggedStudentId;
        public int LoggedStudentId
        {
            get
            {
                return _loggedStudentId;
            }
            set
            {
                _loggedStudentId = value;
                OnPropertyChanged(nameof(LoggedStudentId));
            }
        }
        private ObservableCollection<SubjectLearningMaterial> _subjectLearningMaterialCollection;
        public ObservableCollection<SubjectLearningMaterial> SubjectLearningMaterialCollection
        {
            get
            {
                return _subjectLearningMaterialCollection;
            }
            set
            {
                _subjectLearningMaterialCollection = value;
                OnPropertyChanged(nameof(SubjectLearningMaterialCollection));
            }
        }
    }
}
