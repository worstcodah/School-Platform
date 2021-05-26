using System;
using System.Collections;
using System.Collections.Generic;
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
    public class TeacherMenuGradeServices
    {
        private TeacherMenuGradesVM _teacherMenuGradesVM { get; set; }
        private StudentDAL _studentDAL { get; set; }
        private SubjectClassDAL _subjectClassDAL { get; set; }
        private SemesterDAL _semesterDAL { get; set; }
        private GradeBLL _gradeBLL { get; set; }
        private GradeCollectionItemDAL _gradeCollectionItemDAL { get; set; }
        public TeacherMenuGradeServices(TeacherMenuGradesVM teacherMenuGradesVM)
        {
            _gradeCollectionItemDAL = new GradeCollectionItemDAL();
            _gradeBLL = new GradeBLL();
            _semesterDAL = new SemesterDAL();
            _studentDAL = new StudentDAL();
            _subjectClassDAL = new SubjectClassDAL();
            _teacherMenuGradesVM = teacherMenuGradesVM;
        }
        public bool CanAddGrade(object parameter)
        {
            return _teacherMenuGradesVM.SelectedSemester != null && _teacherMenuGradesVM.SelectedSubjectClass != null && _teacherMenuGradesVM.SelectedStudent != null;
        }
        public void AddGrade(object parameter)
        {
            try
            {
                var selectedStudent = _teacherMenuGradesVM.SelectedStudent;
                var selectedSubjectClass = _teacherMenuGradesVM.SelectedSubjectClass;
                var selectedSemester = _teacherMenuGradesVM.SelectedSemester;
                var newGrade = new Grade(selectedStudent.Id, selectedSubjectClass.IdTeacherSubjectClass, Convert.ToInt32(_teacherMenuGradesVM.GradeValue), _teacherMenuGradesVM.SelectedThesisGradeChoice,
                    _teacherMenuGradesVM.SelectedSemester.Id, _teacherMenuGradesVM.GradeDate);
                var newGradeCollectionItem = new GradeCollectionItem(selectedStudent.Id, selectedSubjectClass.IdSubject, selectedSubjectClass.IdYear, selectedSubjectClass.IdClass,
                    selectedSubjectClass.IdSpecialization, selectedStudent.Name, selectedSubjectClass.SubjectName, selectedSubjectClass.YearName, selectedSubjectClass.ClassName,
                    selectedSubjectClass.SpecializationName, Convert.ToInt32(_teacherMenuGradesVM.GradeValue), _teacherMenuGradesVM.SelectedThesisGradeChoice, _teacherMenuGradesVM.SelectedSemester.Id, _teacherMenuGradesVM.GradeDate);
                _gradeBLL.AddGrade(newGrade, newGradeCollectionItem);
                _teacherMenuGradesVM.GradeCollection = _gradeCollectionItemDAL.GetGradeCollectionItemsForTeacher(_teacherMenuGradesVM.LoggedTeacherId);
            }
            catch (Exception exception) when ( exception is System.FormatException || exception is InvalidDateException || exception is InvalidGradeException)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        public bool CanDeleteGrades(object parameter)
        {
            return CommonServices.CanExecute(parameter);
        }
        public void DeleteGrades(object parameter)
        {
            var dataGrid = parameter as DataGrid;
            if (dataGrid != null)
            {
                var rows = (IEnumerable)CommonServices.GetDataGridRows(dataGrid);
                var updatedCollection = new List<Absence>();
                var gradeCollectionItem = new GradeCollectionItem();
                foreach (DataGridRow row in rows)
                {
                    var columns = dataGrid.Columns;
                    gradeCollectionItem.Id = Convert.ToInt32((columns[0].GetCellContent(row) as TextBlock).Text);
                    gradeCollectionItem.IdStudent = Convert.ToInt32((columns[1].GetCellContent(row) as TextBlock).Text);
                    gradeCollectionItem.StudentName = (columns[2].GetCellContent(row) as TextBlock).Text;
                    gradeCollectionItem.IdClass = Convert.ToInt32((columns[3].GetCellContent(row) as TextBlock).Text);
                    gradeCollectionItem.ClassName = (columns[4].GetCellContent(row) as TextBlock).Text;
                    gradeCollectionItem.IdSpecialization = Convert.ToInt32((columns[5].GetCellContent(row) as TextBlock).Text);
                    gradeCollectionItem.SpecializationName = (columns[6].GetCellContent(row) as TextBlock).Text;
                    gradeCollectionItem.IdYear = Convert.ToInt32((columns[7].GetCellContent(row) as TextBlock).Text);
                    gradeCollectionItem.YearName = (columns[8].GetCellContent(row) as TextBlock).Text;
                    gradeCollectionItem.IdSubject = Convert.ToInt32((columns[9].GetCellContent(row) as TextBlock).Text);
                    gradeCollectionItem.SubjectName = (columns[10].GetCellContent(row) as TextBlock).Text;
                    gradeCollectionItem.GradeValue = (Convert.ToInt32((columns[11].GetCellContent(row) as TextBlock).Text));
                    gradeCollectionItem.IsThesisGrade = Convert.ToBoolean((columns[12].GetCellContent(row) as TextBlock).Text);
                    gradeCollectionItem.IdSemester = Convert.ToInt32((columns[13].GetCellContent(row) as TextBlock).Text);
                    gradeCollectionItem.Date = ((columns[14].GetCellContent(row) as TextBlock).Text);
                    var cellContent = columns[15].GetCellContent(row) as CheckBox;
                    if (cellContent.IsChecked == true)
                    {
                        _gradeCollectionItemDAL.RemoveGrade(gradeCollectionItem);
                    }
                }
                _teacherMenuGradesVM.GradeCollection = _gradeCollectionItemDAL.GetGradeCollectionItemsForTeacher(_teacherMenuGradesVM.LoggedTeacherId);
            }
        }
        public void InitializeFields()
        {
            _teacherMenuGradesVM.AddGradeCommand = new RelayCommand(AddGrade, CanAddGrade);
            _teacherMenuGradesVM.DeleteGradesCommand = new RelayCommand(DeleteGrades, CanDeleteGrades);
            _teacherMenuGradesVM.StudentCollection = _studentDAL.GetStudentsForTeacher(_teacherMenuGradesVM.LoggedTeacherId);
            _teacherMenuGradesVM.SubjectClassCollection = _subjectClassDAL.GetSubjectClassForTeacher(_teacherMenuGradesVM.LoggedTeacherId);
            _teacherMenuGradesVM.SemesterCollection = _semesterDAL.GetAllSemesters();
            _teacherMenuGradesVM.GradeCollection = _gradeCollectionItemDAL.GetGradeCollectionItemsForTeacher(_teacherMenuGradesVM.LoggedTeacherId);
            _teacherMenuGradesVM.IsThesisGradeChoices = new List<bool>();
            _teacherMenuGradesVM.IsThesisGradeChoices.Add(true);
            _teacherMenuGradesVM.IsThesisGradeChoices.Add(false);

        }
    }
}
