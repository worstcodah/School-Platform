using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Tema3.Commands;
using Tema3.Models.DataAccessLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class StudentFinalGradesServices
    {
        private StudentFinalGradesVM _studentFinalGradeVM { get; set; }
        private FinalGradeDAL _finalGradeDAL { get; set; }
        public StudentFinalGradesServices(StudentFinalGradesVM studentFinalGradesVM)
        {
            _finalGradeDAL = new FinalGradeDAL();
            _studentFinalGradeVM = studentFinalGradesVM;
        }
        public void InitializeFields()
        {
            _studentFinalGradeVM.ComputeGeneralAverageCommand = new RelayCommand(this.ComputeGeneralAverage);
            _studentFinalGradeVM.SubjectFinalGradeCollection = _finalGradeDAL.GetFinalGradesByStudentId(_studentFinalGradeVM.LoggedStudentId);
        }
        public void ComputeGeneralAverage(object parameter)
        {
            var sum = 0;
            foreach (var subjectFinalGrade in _studentFinalGradeVM.SubjectFinalGradeCollection)
            {
                sum += subjectFinalGrade.FinalGrade;
            }
            MessageBox.Show("Student's general average is " + sum / _studentFinalGradeVM.SubjectFinalGradeCollection.Count, "General Average"
                , MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
