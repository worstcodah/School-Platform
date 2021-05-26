using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Tema3.Models.BusinessLogicLayer;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class HeadTeacherRepeaterServices
    {
        private HeadTeacherRepeaterVM _headTeacherRepeaterVM { get; set; }
        private FailerDAL _failerDAL { get; set; }
        private StudentBLL _studentBLL { get; set; }
        public HeadTeacherRepeaterServices(HeadTeacherRepeaterVM headTeacherRepeaterVM)
        {
            _studentBLL = new StudentBLL();
            _failerDAL = new FailerDAL();
            _headTeacherRepeaterVM = headTeacherRepeaterVM;
        }
        public void InitializeFields()
        {
            _headTeacherRepeaterVM.RepeaterCollection = _failerDAL.GetFailersByClassId(_headTeacherRepeaterVM.HeadTeacherClassId);
            GetRepeaters();
        }
        public void GetRepeaters()
        {
            var studentsFromClass = _studentBLL.GetStudentsByClassId(_headTeacherRepeaterVM.HeadTeacherClassId);
            var studentsToDelete = new List<Student>();
            foreach (var student in studentsFromClass)
            {
                var failedSubjects = _headTeacherRepeaterVM.RepeaterCollection.Where(s => s.IdStudent == student.Id).ToList();
                if (failedSubjects.Count >= 3)
                {
                    studentsToDelete.Add(student);
                }
            }
            foreach (var studentToDelete in studentsToDelete)
            {
                var newList = _headTeacherRepeaterVM.RepeaterCollection.Where(s => s.IdStudent != studentToDelete.Id).ToList();
                _headTeacherRepeaterVM.RepeaterCollection = new ObservableCollection<Failer>(newList);
            }
        }
    }
}
