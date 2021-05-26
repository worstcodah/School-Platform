using System;
using System.Collections.Generic;
using System.Text;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class AdminServices
    {
        private AdminVM _adminVM;
        public AdminServices(AdminVM adminVM)
        {
            _adminVM = adminVM;
        }
        public void ChangeAddView(object parameter)
        {
            _adminVM.SelectedVM = new EditAdminVM();
        }
        public void ChangeStudentView(object parameter)
        {
            _adminVM.SelectedVM = new StudentAdminVM();
        }
        public void ChangeTeacherView(object parameter)
        {
            _adminVM.SelectedVM = new TeacherAdminVM();
        }
        public void ChangeSubjectView(object parameter)
        {
            _adminVM.SelectedVM = new SubjectAdminVM();
        }
        public void ChangeSubjectYearSpecializationView(object parameter)
        {
            _adminVM.SelectedVM = new SubjectYearSpecializationVM();
        }
        public void ChangeTeacherSubjectClassSpecializationView(object parameter)
        {
            _adminVM.SelectedVM = new TeacherSubjectClassVM();
        }
        public void ChangeStudentClassView(object parameter)
        {
            _adminVM.SelectedVM = new StudentClassVM();
        }
    }
}
