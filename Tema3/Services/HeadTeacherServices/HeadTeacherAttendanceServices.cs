using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using Tema3.Commands;
using Tema3.Models.BusinessLogicLayer;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class HeadTeacherAttendanceServices
    {
        private HeadTeacherAttendanceVM _headTeacherAttendanceVM { get; set; }
        private StudentBLL _studentBLL { get; set; }
        private AbsenceDAL _absenceDAL { get; set; }
        public HeadTeacherAttendanceServices(HeadTeacherAttendanceVM headTeacherAttendanceVM)
        {
            _absenceDAL = new AbsenceDAL();
            _studentBLL = new StudentBLL();
            _headTeacherAttendanceVM = headTeacherAttendanceVM;
        }
        public void InitializeFields()
        {
            _headTeacherAttendanceVM.ChoiceCollection = new ObservableCollection<string>();
            _headTeacherAttendanceVM.ChoiceCollection.Add("For class");
            _headTeacherAttendanceVM.ChoiceCollection.Add("For student");
            _headTeacherAttendanceVM.AbsenceTypeCollection = new ObservableCollection<string>();
            _headTeacherAttendanceVM.AbsenceTypeCollection.Add("All");
            _headTeacherAttendanceVM.AbsenceTypeCollection.Add("Not justified");
            _headTeacherAttendanceVM.StudentBoxVisibility = Visibility.Hidden;
            _headTeacherAttendanceVM.UpdateAbsencesCommand = new RelayCommand(this.UpdateAbsences, this.CanUpdateAbsences);

        }
        public bool CanUpdateAbsences(object parameter)
        {
            switch (_headTeacherAttendanceVM.StudentBoxVisibility)
            {
                case Visibility.Visible:
                    return _headTeacherAttendanceVM.SelectedChoice != null && _headTeacherAttendanceVM.SelectedStudent != null
                        && _headTeacherAttendanceVM.SelectedAbsenceType != null;
                default:
                    return _headTeacherAttendanceVM.SelectedChoice != null && _headTeacherAttendanceVM.SelectedAbsenceType != null;
            }
        }
        public void UpdateAbsences(object parameter)
        {
            var selectedAbsenceType = _headTeacherAttendanceVM.SelectedAbsenceType;
            var selectedChoice = _headTeacherAttendanceVM.SelectedChoice;
            Student selectedStudent;
            if (_headTeacherAttendanceVM.StudentBoxVisibility == Visibility.Visible)
            {
                selectedStudent = _headTeacherAttendanceVM.SelectedStudent;
                switch (selectedAbsenceType)
                {
                    case "All":
                        {
                            _headTeacherAttendanceVM.AbsenceCollection = _absenceDAL.GetAllAbsencesForStudent
                                (_headTeacherAttendanceVM.SelectedStudent);
                            var newList = _headTeacherAttendanceVM.AbsenceCollection.Where(s => s.StudentName ==
               _headTeacherAttendanceVM.SelectedStudent.Name).ToList();
                            _headTeacherAttendanceVM.AbsenceCollection = new ObservableCollection<Absence>(newList);
                            _headTeacherAttendanceVM.TotalNoAbsences = _absenceDAL.GetNoAbsencesForStudent
                                (_headTeacherAttendanceVM.SelectedStudent);
                            break;
                        }
                    case "Not justified":
                        {
                            _headTeacherAttendanceVM.AbsenceCollection = _absenceDAL.GetUnjustifiedAbsencesForStudent
                                (_headTeacherAttendanceVM.SelectedStudent);
                            var newList = _headTeacherAttendanceVM.AbsenceCollection.Where(s => s.StudentName ==
                              _headTeacherAttendanceVM.SelectedStudent.Name).ToList();
                            _headTeacherAttendanceVM.AbsenceCollection = new ObservableCollection<Absence>(newList);
                            _headTeacherAttendanceVM.TotalNoAbsences = _absenceDAL.GetNoUnjustifiedAbsencesForStudent
                                (_headTeacherAttendanceVM.SelectedStudent);
                            break;
                        }
                }
            }
            else
            {
                switch (selectedAbsenceType)
                {
                    case "All":
                        _headTeacherAttendanceVM.AbsenceCollection = _absenceDAL.GetAllAbsencesForClass
                            (_headTeacherAttendanceVM.HeadTeacherClassId);
                        _headTeacherAttendanceVM.TotalNoAbsences = _absenceDAL.GetNoAbsencesForClass
                            (_headTeacherAttendanceVM.HeadTeacherClassId);
                        break;
                    case "Not justified":
                        _headTeacherAttendanceVM.AbsenceCollection = _absenceDAL.GetUnjustifiedAbsencesForClass
                            (_headTeacherAttendanceVM.HeadTeacherClassId);
                        _headTeacherAttendanceVM.TotalNoAbsences = _absenceDAL.GetNoUnjustifiedAbsencesForClass
                            (_headTeacherAttendanceVM.HeadTeacherClassId);
                        break;
                }
            }

        }
        public void InitializeStudentCollection()
        {
            _headTeacherAttendanceVM.StudentCollection = _studentBLL.GetStudentsByClassId(_headTeacherAttendanceVM.HeadTeacherClassId);
        }
        public bool IsStudentSelected()
        {
            return _headTeacherAttendanceVM.SelectedChoice.Equals("For student");
        }
        public void SetVisible()
        {
            _headTeacherAttendanceVM.StudentBoxVisibility = Visibility.Visible;
        }
        public void SetInvisible()
        {
            _headTeacherAttendanceVM.StudentBoxVisibility = Visibility.Hidden;

        }
    }
}
