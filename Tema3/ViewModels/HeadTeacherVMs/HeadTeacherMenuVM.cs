using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Commands;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class HeadTeacherMenuVM : BaseVM
    {
        public RelayCommand ChangeAbsencesViewCommand { get; set; }
        public RelayCommand ChangeAttendanceViewCommand { get; set; }
        public RelayCommand ChangeFailedViewCommand { get; set; }
        public RelayCommand ChangeRepeaterViewCommand { get; set; }
        public RelayCommand ChangeExpelViewCommand { get; set; }
        public RelayCommand ChangeGeneralAveragesViewCommand { get; set; }
        public RelayCommand ChangeHierarchyViewCommand { get; set; }
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
        private int _headTeacherClassId;
        public int HeadTeacherClassId
        {
            get
            {
                return _headTeacherClassId;
            }
            set
            {
                _headTeacherClassId = value;
                OnPropertyChanged(nameof(HeadTeacherClassId));
            }
        }
        private String _headTeacherClassName;
        public String HeadTeacherClassName
        {
            get
            {
                return _headTeacherClassName;
            }
            set
            {
                _headTeacherClassName = value;
                OnPropertyChanged(nameof(HeadTeacherClassName));
            }
        }
        private HeadTeacherMenuServices _headTeacherMenuServices { get; set; }
        public HeadTeacherMenuVM(int loggedTeacherId)
        {
            _headTeacherMenuServices = new HeadTeacherMenuServices(this);
            LoggedTeacherId = loggedTeacherId;
            _headTeacherMenuServices.InitializeFields();
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
