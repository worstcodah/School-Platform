using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Tema3.Exceptions;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.Models.BusinessLogicLayer
{
    public class GradeBLL
    {
        private GradeDAL _gradeDAL { get; set; }
        private GradeCollectionItemDAL _gradeItemCollectionDAL { get; set; }
        public GradeBLL()
        {
            _gradeDAL = new GradeDAL();
            _gradeItemCollectionDAL = new GradeCollectionItemDAL();
        }
        public void AddGrade(Grade grade, GradeCollectionItem gradeCollectionItem)
        {
            string[] formats = { "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MM/yyyy" };
            DateTime dateValue;
            if (!DateTime.TryParseExact(grade.Date, formats, new CultureInfo("en-US"), DateTimeStyles.None, out dateValue))
            {
                throw new InvalidDateException("The introduced date (" + grade.Date + ") is invalid !");
            }
            else if (grade.GradeValue < 1 || grade.GradeValue > 10)
            {
                throw new InvalidGradeException("The introduced grade (" + grade.GradeValue + ") is invalid!");
            }
            else
            {
                _gradeDAL.AddGrade(grade);
            }
        }
    }
}
