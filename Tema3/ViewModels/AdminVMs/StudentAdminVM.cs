using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.ViewModels
{
    public class StudentAdminVM : BaseVM
    {
        private ObservableCollection<Student> _studentCollection;
        public ObservableCollection<Student> StudentCollection
        {
            get
            {
                return _studentCollection;
            }
            set
            {
                _studentCollection = value;
                OnPropertyChanged(nameof(StudentCollection));
            }
        }
        private StudentDAL _studentDAL { get; set; }
        public StudentAdminVM()
        {
            _studentDAL = new StudentDAL();
            StudentCollection = _studentDAL.GetAllStudents();
        }
    }
}
