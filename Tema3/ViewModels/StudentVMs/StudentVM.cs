using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Commands;
using Tema3.Navigation;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class StudentVM : BaseVM
    {
        public RelayCommand LogoutCommand { get; set; }
        public ViewNavigation ViewNavigation { get; set; }
        public RelayCommand ChangeLearningMaterialsViewCommand { get; set; }
        public RelayCommand ChangeGradesViewCommand { get; set; }
        public RelayCommand ChangeAbsencesViewCommand { get; set; }
        public RelayCommand ChangeFinalGradesViewCommand { get; set; }
        private StudentServices _studentServices { get; set; }
        public StudentVM(ViewNavigation viewNavigation, int loggedStudentId)
        {
            this.LoggedStudentId = loggedStudentId;
            ViewNavigation = viewNavigation;
            LogoutCommand = new RelayCommand(CommonServices.Logout);
            _studentServices = new StudentServices(this);
            _studentServices.InitializeFields();
        }
        private BaseVM _selectedVM;
        public BaseVM SelectedVM
        {
            get
            {
                return _selectedVM;
            }
            set
            {
                _selectedVM = value;
                OnPropertyChanged(nameof(SelectedVM));
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
        private String _loggedStudentName;
        public String LoggedStudentName
        {
            get
            {
                return _loggedStudentName;
            }
            set
            {
                _loggedStudentName = value;
                OnPropertyChanged(nameof(LoggedStudentName));
            }
        }
        private String _loggedStudentClassName;
        public String LoggedStudentClassName
        {
            get
            {
                return _loggedStudentClassName;
            }
            set
            {
                _loggedStudentClassName = value;
                OnPropertyChanged(nameof(LoggedStudentClassName));
            }
        }
    }
}
