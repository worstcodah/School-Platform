using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Exceptions;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.Models.BusinessLogicLayer
{
    public class LearningMaterialBLL
    {
        private LearningMaterialDAL _learningMaterialDAL { get; set; }
        public LearningMaterialBLL()
        {
            _learningMaterialDAL = new LearningMaterialDAL();
        }
        public ObservableCollection<LearningMaterial> GetLearningMaterialsForTeacher(int teacherId, int subjectId)
        {
            return _learningMaterialDAL.GetLearningMaterialsForTeacher(teacherId, subjectId);

        }
        public void AddLearningMaterial(LearningMaterial learningMaterial, int idSubjectYearSpecialization)
        {
            if (!_learningMaterialDAL.LearningMaterialExists(learningMaterial))
            {
                _learningMaterialDAL.AddLearningMaterial(learningMaterial, idSubjectYearSpecialization);
            }
            else
            {
                throw new ExistentLearningMaterialException("A learning material with the specified file path" + learningMaterial.FilePath + " already exists !");
            }
        }

        public void DeleteLearningMaterial(LearningMaterial learningMaterial)
        {
            
        }
    }
}
