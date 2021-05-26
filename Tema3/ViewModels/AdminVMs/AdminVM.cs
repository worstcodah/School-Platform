using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Commands;
using Tema3.Navigation;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class AdminVM : BaseVM
    {
        public RelayCommand LogoutCommand { get; set; }
        public RelayCommand ChangeAddViewCommand { get; set; }
        public RelayCommand ChangeStudentViewCommand { get; set; }
        public RelayCommand ChangeTeacherViewCommand { get; set; }
        public RelayCommand ChangeSubjectViewCommand { get; set; }
        public RelayCommand ChangeSubjectYearSpecializationViewCommand { get; set; }
        public RelayCommand ChangeTeacherSubjectClassViewCommand { get; set; }
        public RelayCommand ChangeStudentClassViewCommand { get; set; }
        public ViewNavigation ViewNavigation { get; set; }
        private AdminServices _adminServices { get; set; }
        public AdminVM(ViewNavigation viewNavigation)
        {
            ViewNavigation = viewNavigation;
            LogoutCommand = new RelayCommand(CommonServices.Logout);
            _adminServices = new AdminServices(this);
            ChangeAddViewCommand = new RelayCommand(_adminServices.ChangeAddView);
            ChangeStudentViewCommand = new RelayCommand(_adminServices.ChangeStudentView);
            ChangeTeacherViewCommand = new RelayCommand(_adminServices.ChangeTeacherView);
            ChangeSubjectViewCommand = new RelayCommand(_adminServices.ChangeSubjectView);
            ChangeSubjectYearSpecializationViewCommand = new RelayCommand(_adminServices.ChangeSubjectYearSpecializationView);
            ChangeTeacherSubjectClassViewCommand = new RelayCommand(_adminServices.ChangeTeacherSubjectClassSpecializationView);
            ChangeStudentClassViewCommand = new RelayCommand(_adminServices.ChangeStudentClassView);
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
    }
}
