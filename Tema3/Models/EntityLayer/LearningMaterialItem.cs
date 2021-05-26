using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class LearningMaterialItem : TableInfo
    {
        private String _filePath;
        public String FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }
        public LearningMaterialItem()
        {

        }
        public LearningMaterialItem(int idStudent, int idSubject, int idYear, int idClass, int idSpecialization, String studentName, String subjectName, String yearName, String className,
            String specializationName, int gradeValue, bool isThesisGrade, int idSemester, String date, int id, String filePath) : base(idStudent, idSubject, idYear, idClass, idSpecialization, studentName, subjectName,
                yearName, className, specializationName)
        {
            Id = id;
            FilePath = filePath;
        }
    }
}
