using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Tema3.Commands;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class HeadTeacherHierarchyServices
    {
        private HeadTeacherHierarchyVM _headTeacherHierarchyVM { get; set; }
        private StudentGeneralAverageDAL _studentGeneralAverageDAL { get; set; }
        private FinalGradeDAL _finalGradeDAL { get; set; }
        public HeadTeacherHierarchyServices(HeadTeacherHierarchyVM headTeacherHierarchyVM)
        {
            _finalGradeDAL = new FinalGradeDAL();
            _studentGeneralAverageDAL = new StudentGeneralAverageDAL();
            _headTeacherHierarchyVM = headTeacherHierarchyVM;
        }
        public void InitializeFields()
        {
            _headTeacherHierarchyVM.ShowHierarchyCommand = new RelayCommand(this.UpdateGeneralAverage);
            _headTeacherHierarchyVM.ShowRankingsCommand = new RelayCommand(this.ShowRankings, this.CanShowRankings);
        }
        public bool CanShowRankings(object parameter)
        {
            return _headTeacherHierarchyVM.StudentGeneralAverageCollection != null;
        }
        public void ShowRankings(object parameter)
        {
            var orderedCollection = _headTeacherHierarchyVM.StudentGeneralAverageCollection.OrderByDescending(s => s.GeneralAverage).ToList();
            StudentGeneralAverage first, second, third, fourth;
            first = second = third = fourth = null;
            if (orderedCollection.Count >= 1)
            {
                first = orderedCollection.First();
            }
            if (orderedCollection.Count >= 2)
            {
                second = orderedCollection.ElementAt(1);
            }
            if (orderedCollection.Count >= 3)
            {
                third = orderedCollection.ElementAt(2);
            }
            if (orderedCollection.Count >= 4)
            {
                fourth = orderedCollection.ElementAt(3);
            }
            String firstString, secondString, thirdString, fourthString;
            firstString = secondString = thirdString = fourthString = String.Empty;
            if (first != null)
            {
                if (first.GeneralAverage > 5)
                {
                    firstString = first.Name + " " + first.GeneralAverage;
                }
            }
            if (second != null)
            {
                if (second.GeneralAverage > 5)
                {
                    secondString = second.Name + " " + second.GeneralAverage;
                }
            }
            if (third != null)
            {
                if (third.GeneralAverage > 5)
                {
                    thirdString = third.Name + " " + third.GeneralAverage;
                }
            }
            if (fourth != null)
            {
                if (fourth.GeneralAverage > 5)
                {
                    fourthString = fourth.Name + " " + fourth.GeneralAverage;
                }
            }
            MessageBox.Show("Premiul I: " + firstString + "\nPremiul II: " + secondString + "\nPremiul III: " + thirdString +
                "\nMentiune: " + fourthString);
        }
        public void UpdateGeneralAverage(object parameter)
        {
            _headTeacherHierarchyVM.StudentGeneralAverageCollection = _studentGeneralAverageDAL.GetStudentsByClassId
                (_headTeacherHierarchyVM.HeadTeacherClassId);
            int sum;
            foreach (var studentGeneralAverage in _headTeacherHierarchyVM.StudentGeneralAverageCollection)
            {
                sum = 0;
                var student = new Student(studentGeneralAverage.Id, studentGeneralAverage.Name, studentGeneralAverage.IdClass);
                var finalGrades = _finalGradeDAL.GetFinalGradesForStudent(student);
                foreach (var finalGrade in finalGrades)
                {
                    sum += finalGrade.FinalGradeValue;
                }
                studentGeneralAverage.GeneralAverage = sum / finalGrades.Count;
            }
            var dataGrid = parameter as DataGrid;
            dataGrid.Items.SortDescriptions.Clear();
            dataGrid.Items.SortDescriptions.Add(new SortDescription("GeneralAverage", ListSortDirection.Descending));
            dataGrid.Items.Refresh();
        }
    }
}
