using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Commands;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class TeacherMenuServices 
    {
        private TeacherMenuVM _teacherMenuVM { get; set; }
        public TeacherMenuServices(TeacherMenuVM teacherMenuVM)
        {
            _teacherMenuVM = teacherMenuVM;
        }
        public void InitializeFields()
        {
            _teacherMenuVM.ChangeAttendanceViewCommand = new RelayCommand(this.ChangeAttendanceView);
            _teacherMenuVM.ChangeGradesViewCommand = new RelayCommand(this.ChangeGradesView);
            _teacherMenuVM.ChangeLearningMaterialsViewCommand = new RelayCommand(this.ChangeLearningMaterialsView);
            _teacherMenuVM.ChangeMeanViewCommand = new RelayCommand(this.ChangeMeanView);
        }
        public void ChangeAttendanceView(object parameter)
        {
            _teacherMenuVM.SelectedVM = new TeacherMenuAttendanceVM(_teacherMenuVM.LoggedTeacherId);
        }
        public void ChangeGradesView(object parameter)
        {
            _teacherMenuVM.SelectedVM = new TeacherMenuGradesVM(_teacherMenuVM.LoggedTeacherId);
        }
        public void ChangeLearningMaterialsView(object parameter)
        {
            _teacherMenuVM.SelectedVM = new TeacherMenuLearningMaterialsVM(_teacherMenuVM.LoggedTeacherId);
        }
        public void ChangeMeanView(object parameter)
        {
            _teacherMenuVM.SelectedVM = new TeacherMenuMeanVM(_teacherMenuVM.LoggedTeacherId);
        }
    }
}
