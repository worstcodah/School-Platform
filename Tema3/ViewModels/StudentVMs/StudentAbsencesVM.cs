using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Models.EntityLayer;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class StudentAbsencesVM : BaseVM
    {
        private ObservableCollection<Absence> _absenceCollection;
        public ObservableCollection<Absence> AbsenceCollection
        {
            get
            {
                return _absenceCollection;
            }
            set
            {
                _absenceCollection = value;
                OnPropertyChanged(nameof(AbsenceCollection));
            }
        }
        private int _loggedStudentId;
        public int LoggedStudentId
        {
            get
            {
                return _loggedStudentId;
            }
            set
            {
                _loggedStudentId = value;
                OnPropertyChanged(nameof(LoggedStudentId));
            }
        }
        private StudentAbsencesServices _studentAbsencesServices { get; set; }
        public StudentAbsencesVM(int loggedStudentId)
        {
            LoggedStudentId = loggedStudentId;
            _studentAbsencesServices = new StudentAbsencesServices(this);
            _studentAbsencesServices.InitializeFields();
        }
    }
}
