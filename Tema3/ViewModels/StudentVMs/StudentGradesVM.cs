using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Models.EntityLayer;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class StudentGradesVM : BaseVM
    {
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
        private ObservableCollection<GradeCollectionItem> _gradeItemCollection;
        public ObservableCollection<GradeCollectionItem> GradeItemCollection
        {
            get
            {
                return _gradeItemCollection;
            }
            set
            {
                _gradeItemCollection = value;
                OnPropertyChanged(nameof(GradeItemCollection));
            }
        }
        private StudentGradesServices _studentGradesServices { get; set; }
        public StudentGradesVM(int loggedStudentId)
        {
            LoggedStudentId = loggedStudentId;
            _studentGradesServices = new StudentGradesServices(this);
            _studentGradesServices.InitializeFields();
        }
    }
}
