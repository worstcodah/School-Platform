using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Tema3.Models.BusinessLogicLayer;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.ViewModels;

namespace Tema3.Services.HeadTeacherServices
{
    public class HeadTeacherFailedServices
    {
        private HeadTeacherFailedVM _headTeacherFailedVM { get; set; }
        private FailerDAL _failerDAL { get; set; }
        private StudentBLL _studentBLL { get; set; }
        public HeadTeacherFailedServices(HeadTeacherFailedVM headTeacherFailedVM)
        {
            _studentBLL = new StudentBLL();
            _failerDAL = new FailerDAL();
            _headTeacherFailedVM = headTeacherFailedVM;
        }
        public void InitializeFields()
        {
            _headTeacherFailedVM.FailerCollection = _failerDAL.GetFailersByClassId(_headTeacherFailedVM.HeadTeacherClassId);
            GetFailers();
        }
        public void GetFailers()
        {

            var studentsFromClass = _studentBLL.GetStudentsByClassId(_headTeacherFailedVM.HeadTeacherClassId);
            var studentsToDelete = new List<Student>();
            foreach (var student in studentsFromClass)
            {
                var failedSubjects = _headTeacherFailedVM.FailerCollection.Where(s => s.IdStudent == student.Id).ToList();
                if (failedSubjects.Count > 3 || failedSubjects.Count < 1)
                {
                    studentsToDelete.Add(student);
                }
            }
            foreach (var studentToDelete in studentsToDelete)
            {
                var newList = _headTeacherFailedVM.FailerCollection.Where(s => s.IdStudent != studentToDelete.Id).ToList();
                _headTeacherFailedVM.FailerCollection = new ObservableCollection<Failer>(newList);
            }


            /*
            var entriesToRemove = new List<Failer>();
            foreach(var student in _headTeacherFailedVM.FailerCollection)
            {
                if (entriesToRemove.)
                {
                    continue;
                }
                var failedSubjects = _headTeacherFailedVM.FailerCollection.Where(s=> s.FinalGradeValue < 5 && s.IdStudent==s.IdStudent)
                    .ToList();
                if (failedSubjects.Count > 3)
                {
                    entriesToRemove.Add(student);
                }
            }
            foreach(var entry in entriesToRemove)
            {

            }
            */
        }
    }
}
