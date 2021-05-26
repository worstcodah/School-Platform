using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Commands;
using Tema3.Models.EntityLayer;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class StudentFinalGradesVM : BaseVM
    {
        private ObservableCollection<SubjectFinalGrade> _subjectFinalGradeCollection;
        public ObservableCollection<SubjectFinalGrade> SubjectFinalGradeCollection
        {
            get
            {
                return _subjectFinalGradeCollection;
            }
            set
            {
                _subjectFinalGradeCollection = value;
                OnPropertyChanged(nameof(SubjectFinalGradeCollection));
            }
        }
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
        private StudentFinalGradesServices _studentFinalGradesServices { get; set; }
        public RelayCommand ComputeGeneralAverageCommand { get; set; }
        public StudentFinalGradesVM(int loggedStudentId)
        {
            LoggedStudentId = loggedStudentId;
            _studentFinalGradesServices = new StudentFinalGradesServices(this);
            _studentFinalGradesServices.InitializeFields();
        }
    }
}
