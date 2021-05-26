using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.ViewModels
{
    public class TeacherAdminVM : BaseVM
    {
        private ObservableCollection<Teacher> _teacherCollection;
        public ObservableCollection<Teacher> TeacherCollection
        {
            get
            {
                return _teacherCollection;
            }
            set
            {
                _teacherCollection = value;
                OnPropertyChanged(nameof(TeacherCollection));
            }
        }
        private TeacherDAL _teacherDAL { get; set; }
        public TeacherAdminVM()
        {
            _teacherDAL = new TeacherDAL();
            TeacherCollection = _teacherDAL.GetAllTeachers();
        }
    }
}
