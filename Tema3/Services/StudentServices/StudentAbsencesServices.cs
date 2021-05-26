using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Models.DataAccessLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class StudentAbsencesServices
    {
        private StudentAbsencesVM _studentAbsencesVM { get; set; }
        private AbsenceDAL _absenceDAL { get; set; }
        public StudentAbsencesServices(StudentAbsencesVM studentAbsencesVM)
        {
            _absenceDAL = new AbsenceDAL();
            _studentAbsencesVM = studentAbsencesVM;
        }
        public void InitializeFields()
        {
            _studentAbsencesVM.AbsenceCollection = _absenceDAL.GetAbsencesByStudentId(_studentAbsencesVM.LoggedStudentId);
        }
    }
}
