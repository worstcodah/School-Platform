using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Models.DataAccessLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class StudentLearningMaterialsServices
    {
        private StudentLearningMaterialsVM _studentLearningMaterialsVM { get; set; }
        private LearningMaterialDAL _learningMaterialDAL { get; set; }
        public StudentLearningMaterialsServices(StudentLearningMaterialsVM studentLearningMaterialsVM)
        {
            _learningMaterialDAL = new LearningMaterialDAL();
            _studentLearningMaterialsVM = studentLearningMaterialsVM;
        }
        public void InitializeFields()
        {
            _studentLearningMaterialsVM.SubjectLearningMaterialCollection = _learningMaterialDAL.GetSubjectLearningMaterialsByStudentId(
                _studentLearningMaterialsVM.LoggedStudentId);
        }
    }
}
