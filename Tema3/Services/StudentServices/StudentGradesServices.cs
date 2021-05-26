using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Models.DataAccessLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class StudentGradesServices
    {
        private StudentGradesVM _studentGradesVM { get; set; }
        private GradeCollectionItemDAL _gradeItemCollectionDAL { get; set; }
        public StudentGradesServices(StudentGradesVM studentGradesVM)
        {
            _gradeItemCollectionDAL = new GradeCollectionItemDAL();
            _studentGradesVM = studentGradesVM;
        }
        public void InitializeFields()
        {
            _studentGradesVM.GradeItemCollection = _gradeItemCollectionDAL.GetGradesByStudentId(_studentGradesVM.LoggedStudentId);
        }
    }
}
