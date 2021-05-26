using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Tema3.Commands;
using Tema3.Models.BusinessLogicLayer;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class TeacherMenuMeanServices
    {
        private TeacherMenuMeanVM _teacherMenuMeanVM { get; set; }
        private SubjectYearSpecializationDAL _subjectYearSpecializationDAL { get; set; }
        private StudentFinalGradeDAL _studentFinalGradeDAL { get; set; }
        private TeacherSubjectClassDAL _teacherSubjectClassDAL { get; set; }
        private GradeDAL _gradeDAL { get; set; }
        public TeacherMenuMeanServices(TeacherMenuMeanVM teacherMenuMeanVM)
        {
            _teacherSubjectClassDAL = new TeacherSubjectClassDAL();
            _gradeDAL = new GradeDAL();
            _studentFinalGradeDAL = new StudentFinalGradeDAL();
            _teacherMenuMeanVM = teacherMenuMeanVM;
            _subjectYearSpecializationDAL = new SubjectYearSpecializationDAL();
        }
        public void InitializeFields()
        {
            _teacherMenuMeanVM.SubjectYearSpecializationCollection = _subjectYearSpecializationDAL.GetSubjectYearSpecializationForTeacher(_teacherMenuMeanVM.LoggedTeacherId);
            _teacherMenuMeanVM.CalculateMeanCommand = new RelayCommand(this.CalculateMean);
        }
        public void GetSpecificStudents()
        {
            _teacherMenuMeanVM.StudentFinalGradeCollection = _studentFinalGradeDAL.GetSpecificStudents(_teacherMenuMeanVM.LoggedTeacherId
                ,_teacherMenuMeanVM.SelectedSubjectYearSpecialization.IdSpecialization, _teacherMenuMeanVM.SelectedSubjectYearSpecialization. 
                IdYear);
        }
        public void CalculateMean(object parameter)
        {
            var dataGrid = parameter as DataGrid;
            if (dataGrid != null)
            {
                var rows = (IEnumerable)CommonServices.GetDataGridRows(dataGrid);
                var student = new Student();
                foreach (DataGridRow row in rows)
                {
                    var columns = dataGrid.Columns;
                    student.Id = Convert.ToInt32((columns[0].GetCellContent(row) as TextBlock).Text);
                    student.Name = (columns[1].GetCellContent(row) as TextBlock).Text;
                    student.IdClass = Convert.ToInt32((columns[2].GetCellContent(row) as TextBlock).Text);
                    var idTeacherSubjectClass = _teacherSubjectClassDAL.GetTeacherSubjectClassId(student.IdClass, _teacherMenuMeanVM.SelectedSubjectYearSpecialization.IdSubject, _teacherMenuMeanVM.LoggedTeacherId);
                    var gradesList = _gradeDAL.GetGradesForStudent(student);
                    gradesList = gradesList.Where(s => s.IdTeacherSubjectClass == idTeacherSubjectClass).ToList();
                    var isThesis = _teacherSubjectClassDAL.IsThesisSubject(idTeacherSubjectClass);
                    var mean = 0;
                    if (!isThesis && gradesList.Count >= 3)
                    {
                        foreach (var grade in gradesList)
                        {
                            mean += grade.GradeValue;
                        }
                        mean = mean / gradesList.Count;
                    }
                    else if (gradesList.Count >= 4 && gradesList.Single(s => s.IsThesisGrade == true) != null)
                    {
                        var thesisGrade = gradesList.Single(s => s.IsThesisGrade == true);
                        foreach (var grade in gradesList)
                        {
                            mean += grade.GradeValue;
                        }
                        mean = (3 * (mean / gradesList.Count)) / 4;
                        thesisGrade.GradeValue = thesisGrade.GradeValue / 4;
                        mean = mean + thesisGrade.GradeValue;
                    }
                    _studentFinalGradeDAL.UpdateFinalGrade(idTeacherSubjectClass, mean, student.Id);

                }
                _teacherMenuMeanVM.StudentFinalGradeCollection = _studentFinalGradeDAL.GetSpecificStudents(_teacherMenuMeanVM.LoggedTeacherId, 
                    _teacherMenuMeanVM.SelectedSubjectYearSpecialization.IdSpecialization, _teacherMenuMeanVM.SelectedSubjectYearSpecialization.IdYear);
            }

        }
    }
}
