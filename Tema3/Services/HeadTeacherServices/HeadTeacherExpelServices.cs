using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Models.BusinessLogicLayer;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.ViewModels;

namespace Tema3.Services.HeadTeacherServices
{
    public class HeadTeacherExpelServices
    {
        private HeadTeacherExpelVM _headTeacherExpelVM { get; set; }
        private StudentBLL _studentBLL { get; set; }
        private AbsenceDAL _absenceDAL { get; set; }
        public HeadTeacherExpelServices(HeadTeacherExpelVM headTeacherExpelVM)
        {
            _absenceDAL = new AbsenceDAL();
            _studentBLL = new StudentBLL();
            _headTeacherExpelVM = headTeacherExpelVM;
        }
        public void InitializeFields()
        {
            _headTeacherExpelVM.ExpelleeCollection = _studentBLL.GetStudentsByClassId(_headTeacherExpelVM.HeadTeacherClassId);
            var studentsNotExpelledList = new List<Student>();
            foreach(var student in _headTeacherExpelVM.ExpelleeCollection)
            {
                var noAbsences = _absenceDAL.GetNoAbsencesForStudent(student);
                if(noAbsences <= Constants.Constants.MaxNoAbsences)
                {
                    studentsNotExpelledList.Add(student);
                }
            }
            foreach(var studentNotExpelled in studentsNotExpelledList)
            {
                _headTeacherExpelVM.ExpelleeCollection.Remove(studentNotExpelled);
            }
        }
    }
}
