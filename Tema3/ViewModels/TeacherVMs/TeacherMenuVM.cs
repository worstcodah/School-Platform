using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Commands;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class TeacherMenuVM : BaseVM
    {
        public RelayCommand ChangeLearningMaterialsViewCommand { get; set; }
        public RelayCommand ChangeGradesViewCommand { get; set; }
        public RelayCommand ChangeAttendanceViewCommand { get; set; }
        public RelayCommand ChangeMeanViewCommand { get; set; }
        private TeacherMenuServices _teacherMenuServices { get; set; }
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
        public TeacherMenuVM(int loggedTeacherId)
        {
            LoggedTeacherId = loggedTeacherId;
            _teacherMenuServices = new TeacherMenuServices(this);
            _teacherMenuServices.InitializeFields();
        }
        public TeacherMenuVM()
        {

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
