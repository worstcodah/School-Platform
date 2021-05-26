using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Tema3.Exceptions;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.Models.BusinessLogicLayer
{
    public class AbsenteeBLL
    {
        private AbsenteeDAL _absenteeDAL { get; set; }
        private AbsenceDAL _absenceDAL { get; set; }
        public AbsenteeBLL()
        {
            _absenceDAL = new AbsenceDAL();
            _absenteeDAL = new AbsenteeDAL();
        }
        public void AddAbsentee(Absentee absentee, Absence absence)
        {
            string[] formats = { "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MM/yyyy" };
            DateTime dateValue;
            if (!DateTime.TryParseExact(absentee.Date, formats, new CultureInfo("en-US"), DateTimeStyles.None, out dateValue))
            {
                throw new InvalidDateException("The date introduced (" + absentee.Date + " is invalid !");
            }
            if (!_absenceDAL.AbsenceExists(absence))
            {
                _absenteeDAL.AddAbsentee(absentee);
            }
            else
            {
                throw new ExistentAbsenteeException("The student with id " + absentee.IdStudent + ") already has an absence on date " + absentee.Date + " at the subject linked to the TeacherSubjectClass" +
                    "entry with id" + absentee.IdTeacherSubjectClass + "!");
            }
        }
    }
}
