using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Commands;
using Tema3.Models.BusinessLogicLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class StudentServices
    {
        private StudentVM _studentVM { get; set; }
        private StudentBLL _studentBLL { get; set; }
        public StudentServices(StudentVM studentVM)
        {
            _studentBLL = new StudentBLL();
            _studentVM = studentVM;
        }
        public void ChangeAbsencesView(object parameter)
        {
            _studentVM.SelectedVM = new StudentAbsencesVM(_studentVM.LoggedStudentId);
        }
        public void ChangeGradesView(object parameter)
        {
            _studentVM.SelectedVM = new StudentGradesVM(_studentVM.LoggedStudentId);
        }
        public void ChangeLearningMaterialsView(object parameter)
        {
            _studentVM.SelectedVM = new StudentLearningMaterialsVM(_studentVM.LoggedStudentId);
        }
        public void ChangeFinalGradesView(object parameter)
        {
            _studentVM.SelectedVM = new StudentFinalGradesVM(_studentVM.LoggedStudentId);
        }
        public void InitializeFields()
        {
            _studentVM.ChangeAbsencesViewCommand = new RelayCommand(this.ChangeAbsencesView);
            _studentVM.ChangeFinalGradesViewCommand = new RelayCommand(this.ChangeFinalGradesView);
            _studentVM.ChangeLearningMaterialsViewCommand = new RelayCommand(this.ChangeLearningMaterialsView);
            _studentVM.ChangeGradesViewCommand = new RelayCommand(this.ChangeGradesView);
            _studentVM.LoggedStudentClassName = _studentBLL.GetClassNameByStudentId(_studentVM.LoggedStudentId);
            _studentVM.LoggedStudentName = _studentBLL.GetStudentNameByStudentId(_studentVM.LoggedStudentId);
        }
    }
}
