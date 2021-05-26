using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Commands;
using Tema3.Models.DataAccessLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class HeadTeacherMenuServices
    {
        private HeadTeacherMenuVM _headTeacherMenuVM { get; set; }
        private TeacherDAL _teacherDAL { get; set; }
        public HeadTeacherMenuServices(HeadTeacherMenuVM headTeacherMenuVM)
        {
            _teacherDAL = new TeacherDAL();
            _headTeacherMenuVM = headTeacherMenuVM;
        }
        public void ChangeAbsencesView(object parameter)
        {
            _headTeacherMenuVM.SelectedVM = new HeadTeacherAbsencesVM(_headTeacherMenuVM.HeadTeacherClassId);
        }
        public void ChangeAttendanceView(object parameter)
        {
            _headTeacherMenuVM.SelectedVM = new HeadTeacherAttendanceVM(_headTeacherMenuVM.HeadTeacherClassId);
        }
        public void ChangeFailedView(object parameter)
        {
            _headTeacherMenuVM.SelectedVM = new HeadTeacherFailedVM(_headTeacherMenuVM.HeadTeacherClassId);
        }
        public void ChangeRepeaterView(object parameter)
        {
            _headTeacherMenuVM.SelectedVM = new HeadTeacherRepeaterVM(_headTeacherMenuVM.HeadTeacherClassId);
        }
        public void ChangeExpelView(object parameter)
        {
            _headTeacherMenuVM.SelectedVM = new HeadTeacherExpelVM(_headTeacherMenuVM.HeadTeacherClassId);
        }
        public void ChangeGeneralAveragesView(object parameter)
        {
            _headTeacherMenuVM.SelectedVM = new HeadTeacherGeneralAveragesVM(_headTeacherMenuVM.HeadTeacherClassId);
        }
        public void ChangeHierarchyView(object parameter)
        {
            _headTeacherMenuVM.SelectedVM = new HeadTeacherHierarchyVM(_headTeacherMenuVM.HeadTeacherClassId);
        }
        public void InitializeFields()
        {
            _headTeacherMenuVM.HeadTeacherClassId = _teacherDAL.HeadTeacherClassId(_headTeacherMenuVM.LoggedTeacherId);
            _headTeacherMenuVM.HeadTeacherClassName = _teacherDAL.HeadTeacherClassString(_headTeacherMenuVM.LoggedTeacherId);
            _headTeacherMenuVM.ChangeRepeaterViewCommand = new RelayCommand(this.ChangeRepeaterView);
            _headTeacherMenuVM.ChangeAbsencesViewCommand = new RelayCommand(this.ChangeAbsencesView);
            _headTeacherMenuVM.ChangeFailedViewCommand = new RelayCommand(this.ChangeFailedView);
            _headTeacherMenuVM.ChangeExpelViewCommand = new RelayCommand(this.ChangeExpelView);
            _headTeacherMenuVM.ChangeAttendanceViewCommand = new RelayCommand(this.ChangeAttendanceView);
            _headTeacherMenuVM.ChangeGeneralAveragesViewCommand = new RelayCommand(this.ChangeGeneralAveragesView);
            _headTeacherMenuVM.ChangeHierarchyViewCommand = new RelayCommand(this.ChangeHierarchyView);
        }

    }
}
