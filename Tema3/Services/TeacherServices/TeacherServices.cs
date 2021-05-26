using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Commands;
using Tema3.Models.BusinessLogicLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class TeacherServices
    {
        private TeacherVM _teacherVM { get; set; }
        private HeadTeacherBLL _headTeacherBLL { get; set; }
        public TeacherServices(TeacherVM teacherVM)
        {
            _teacherVM = teacherVM;
            _headTeacherBLL = new HeadTeacherBLL();
        }
        public void ChangeTeacherMenuView(object parameter)
        {
            _teacherVM.SelectedVM = new TeacherMenuVM(_teacherVM.LoggedTeacherId);    
        }
        public void ChangeHeadTeacherMenuView(object parameter)
        {
            _teacherVM.SelectedVM = new HeadTeacherMenuVM(_teacherVM.LoggedTeacherId);
        }
        public bool CanSelectHeadTeacherMenu(object parameter)
        {
            return _headTeacherBLL.IsAlreadyHeadTeacher(_teacherVM.LoggedTeacherId);
        }
        public void InitializeFields()
        {
            _teacherVM.LogoutCommand = new RelayCommand(CommonServices.Logout);
            _teacherVM.ChangeHeadTeacherMenuViewCommand = new RelayCommand(this.ChangeHeadTeacherMenuView, this.CanSelectHeadTeacherMenu);
            _teacherVM.ChangeTeacherMenuViewCommand = new RelayCommand(this.ChangeTeacherMenuView);
        }
    }
}
