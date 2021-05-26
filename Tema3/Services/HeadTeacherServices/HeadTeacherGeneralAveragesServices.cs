using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Models.BusinessLogicLayer;
using Tema3.Models.DataAccessLayer;
using Tema3.ViewModels;

namespace Tema3.Services.HeadTeacherServices
{
    public class HeadTeacherGeneralAveragesServices
    {
        private HeadTeacherGeneralAveragesVM _headTeacherGeneralAveragesVM { get; set; }
        private FinalGradeDAL _finalGradeDAL { get; set; }
        private StudentBLL _studentBLL { get; set; }
        public HeadTeacherGeneralAveragesServices(HeadTeacherGeneralAveragesVM headTeacherGeneralAveragesVM)
        {
            _finalGradeDAL = new FinalGradeDAL();
            _studentBLL = new StudentBLL();
            _headTeacherGeneralAveragesVM = headTeacherGeneralAveragesVM;
        }
        public void InitializeFields()
        {
            _headTeacherGeneralAveragesVM.StudentCollection = _studentBLL.GetStudentsByClassId
                (_headTeacherGeneralAveragesVM.HeadTeacherClassId);
        }
        public void UpdateFinalGrades()
        {
            _headTeacherGeneralAveragesVM.FinalGradeCollection = _finalGradeDAL.GetFinalGradesForStudent
                (_headTeacherGeneralAveragesVM.SelectedStudent);
        }
        public void UpdateGeneralAverage()
        {
            var sum = 0;
            foreach(var finalGrade in _headTeacherGeneralAveragesVM.FinalGradeCollection)
            {
                sum += finalGrade.FinalGradeValue;
            }
            _headTeacherGeneralAveragesVM.GeneralAverage = sum / _headTeacherGeneralAveragesVM.FinalGradeCollection.Count;
        }
    }
}
