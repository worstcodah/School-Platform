using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Commands;
using Tema3.Navigation;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class TeacherVM : BaseVM
    {
        public RelayCommand LogoutCommand { get; set; }
        public RelayCommand ChangeTeacherMenuViewCommand { get; set; }
        public RelayCommand ChangeHeadTeacherMenuViewCommand { get; set; }
        public ViewNavigation ViewNavigation { get; set; }
        private TeacherServices _teacherServices { get; set; }
        public TeacherVM(ViewNavigation viewNavigation, int loggedTeacherId)
        {
            ViewNavigation = viewNavigation;
            _teacherServices = new TeacherServices(this);
            _teacherServices.InitializeFields();
            _loggedTeacherId = loggedTeacherId;
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
    }
}
