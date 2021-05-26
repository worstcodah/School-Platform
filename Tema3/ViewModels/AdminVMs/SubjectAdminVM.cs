using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.ViewModels
{
    public class SubjectAdminVM : BaseVM
    {
        private ObservableCollection<Subject> _subjectCollection;
        public ObservableCollection<Subject> SubjectCollection
        {
            get
            {
                return _subjectCollection;
            }
            set
            {
                _subjectCollection = value;
                OnPropertyChanged(nameof(SubjectCollection));
            }
        }
        private SubjectDAL _subjectDAL { get; set; }
        public SubjectAdminVM()
        {
            _subjectDAL = new SubjectDAL();
            SubjectCollection = _subjectDAL.GetAllSubjects();
        }
    }
}
