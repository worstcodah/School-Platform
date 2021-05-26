using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Tema3.Commands;
using Tema3.Exceptions;
using Tema3.Models.BusinessLogicLayer;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class TeacherMenuAttendanceServices
    {
        private TeacherMenuAttendanceVM _teacherMenuAttendanceVM { get; set; }
        private AbsenteeBLL _absenteeBLL { get; set; }
        private AbsenceDAL _absenceDAL { get; set; }
        private StudentBLL _studentBLL { get; set; }
        private SemesterDAL _semesterDAL { get; set; }
        private SubjectClassDAL _subjectClassDAL { get; set; }
        public TeacherMenuAttendanceServices(TeacherMenuAttendanceVM teacherMenuAttendanceVM)
        {
            _semesterDAL = new SemesterDAL();
            _absenteeBLL = new AbsenteeBLL();
            _absenceDAL = new AbsenceDAL();
            _studentBLL = new StudentBLL();
            _subjectClassDAL = new SubjectClassDAL();
            _teacherMenuAttendanceVM = teacherMenuAttendanceVM;
        }
        public void MarkAbsence(object parameter)
        {
            try
            {
                var selectedStudent = _teacherMenuAttendanceVM.SelectedStudent;
                var selectedSubjectClass = _teacherMenuAttendanceVM.SelectedSubjectClass;
                var newAbsentee = new Absentee(_teacherMenuAttendanceVM.SelectedStudent.Id, _teacherMenuAttendanceVM.SelectedSubjectClass.IdTeacherSubjectClass,
                    false, _teacherMenuAttendanceVM.AbsenceDate, _teacherMenuAttendanceVM.SelectedSemester.Id);
                var newAbsence = new Absence(selectedStudent.Id, selectedStudent.Name, selectedSubjectClass.IdClass, selectedSubjectClass.ClassName, selectedSubjectClass.IdSpecialization,
                    selectedSubjectClass.SpecializationName, selectedSubjectClass.IdYear, selectedSubjectClass.YearName, selectedSubjectClass.IdSubject,
                    selectedSubjectClass.SubjectName, false, _teacherMenuAttendanceVM.AbsenceDate, _teacherMenuAttendanceVM.SelectedSemester.Id);
                _absenteeBLL.AddAbsentee(newAbsentee, newAbsence);
                _teacherMenuAttendanceVM.AbsenceCollection = _absenceDAL.GetAbsencesForTeacher(_teacherMenuAttendanceVM.LoggedTeacherId);
            }
            catch (Exception exception) when (exception is InvalidDateException || exception is ExistentAbsenteeException || exception is System.FormatException)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        public bool CanMarkAbsence(object parameter)
        {
            return _teacherMenuAttendanceVM.SelectedStudent != null && !String.IsNullOrWhiteSpace(_teacherMenuAttendanceVM.AbsenceDate) && _teacherMenuAttendanceVM.SelectedSubjectClass != null;
        }
        public bool CanMotivateAbsences(object parameter)
        {
            return CommonServices.CanExecute(parameter);

        }
        

        public void MotivateAbsences(object parameter)
        {
            var dataGrid = parameter as DataGrid;
            if (dataGrid != null)
            {
                var rows = (IEnumerable)CommonServices.GetDataGridRows(dataGrid);
                var updatedCollection = new List<Absence>();
                var absence = new Absence();
                foreach (DataGridRow row in rows)
                {
                    var columns = dataGrid.Columns;
                    absence.Id = Convert.ToInt32((columns[0].GetCellContent(row) as TextBlock).Text);
                    absence.IdStudent = Convert.ToInt32((columns[1].GetCellContent(row) as TextBlock).Text);
                    absence.StudentName = (columns[2].GetCellContent(row) as TextBlock).Text;
                    absence.IdClass = Convert.ToInt32((columns[3].GetCellContent(row) as TextBlock).Text);
                    absence.ClassName = (columns[4].GetCellContent(row) as TextBlock).Text;
                    absence.IdSpecialization = Convert.ToInt32((columns[5].GetCellContent(row) as TextBlock).Text);
                    absence.SpecializationName = (columns[6].GetCellContent(row) as TextBlock).Text;
                    absence.IdYear = Convert.ToInt32((columns[7].GetCellContent(row) as TextBlock).Text);
                    absence.YearName = (columns[8].GetCellContent(row) as TextBlock).Text;
                    absence.IdSubject = Convert.ToInt32((columns[9].GetCellContent(row) as TextBlock).Text);
                    absence.SubjectName = (columns[10].GetCellContent(row) as TextBlock).Text;
                    absence.IsMotivated = (Convert.ToBoolean((columns[11].GetCellContent(row) as TextBlock).Text));
                    absence.Date = (columns[12].GetCellContent(row) as TextBlock).Text;
                    absence.IdSemester = Convert.ToInt32((columns[13].GetCellContent(row) as TextBlock).Text);
                    var cellContent = columns[14].GetCellContent(row) as CheckBox;
                    if (cellContent.IsChecked == true)
                    {
                        _absenceDAL.MotivateAbsence(absence);
                    }
                }
                _teacherMenuAttendanceVM.AbsenceCollection = _absenceDAL.GetAbsencesForTeacher(_teacherMenuAttendanceVM.LoggedTeacherId);
            }


        }
        public void InitializeFields()
        {
            _teacherMenuAttendanceVM.MotivateAbsencesCommand = new RelayCommand(this.MotivateAbsences, this.CanMotivateAbsences);
            _teacherMenuAttendanceVM.MarkAbsenceCommand = new RelayCommand(this.MarkAbsence, this.CanMarkAbsence);
            _teacherMenuAttendanceVM.AbsenceCollection = _absenceDAL.GetAbsencesForTeacher(_teacherMenuAttendanceVM.LoggedTeacherId);
            _teacherMenuAttendanceVM.StudentCollection = _studentBLL.GetStudentsForTeacher(_teacherMenuAttendanceVM.LoggedTeacherId);
            _teacherMenuAttendanceVM.SubjectClassCollection = _subjectClassDAL.GetSubjectClassForTeacher(_teacherMenuAttendanceVM.LoggedTeacherId);
            _teacherMenuAttendanceVM.SemesterCollection = _semesterDAL.GetAllSemesters();
        }
    }
}
