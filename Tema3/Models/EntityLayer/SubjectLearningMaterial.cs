using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class SubjectLearningMaterial : BasePropertyChanged
    {
        private int _idSubject;
        public int IdSubject
        {
            get
            {
                return _idSubject;
            }
            set
            {
                _idSubject = value;
                OnPropertyChanged(nameof(IdSubject));
            }
        }
        private String _subjectName;
        public String SubjectName
        {
            get
            {
                return _subjectName;
            }
            set
            {
                _subjectName = value;
                OnPropertyChanged(nameof(SubjectName));
            }
        }
        private int _idLearningMaterial;
        public int IdLearningMaterial
        {
            get
            {
                return _idLearningMaterial;
            }
            set
            {
                _idLearningMaterial = value;
                OnPropertyChanged(nameof(IdLearningMaterial));
            }
        }
        private String _learningMaterialPath;
        public String LearningMaterialPath
        {
            get
            {
                return _learningMaterialPath;
            }
            set
            {
                _learningMaterialPath = value;
                OnPropertyChanged(nameof(LearningMaterialPath));
            }
        }
    }
}
