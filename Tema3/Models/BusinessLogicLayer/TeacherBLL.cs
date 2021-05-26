using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Exceptions;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.Models.BusinessLogicLayer
{
    public class TeacherBLL
    {
        private TeacherDAL _teacherDAL { get; set; }
        public TeacherBLL()
        {
            _teacherDAL = new TeacherDAL();
        }
        public ObservableCollection<Teacher> GetAllTeachers()
        {
            return _teacherDAL.GetAllTeachers();
        }
        public void AddTeacher(Teacher teacher)
        {
            if (!_teacherDAL.TeacherExists(teacher))
            {
                _teacherDAL.AddTeacher(teacher);
            }
            else
            {
                throw new ExistentTeacherException("The table Teacher already contains an entry with the id " + teacher.Id + "!");
            }
        }

        public void DeleteTeacher(Teacher teacher)
        {
            if (_teacherDAL.TeacherExists(teacher))
            {
                _teacherDAL.DeleteTeacher(teacher);
            }
            else
            {
                throw new NonExistentTeacherException("The table Teacher doesn't contain an entry with the id " + teacher.Id + "!");
            }
        }

        public void ModifyTeacher(Teacher teacher)
        {
            if (_teacherDAL.TeacherExists(teacher))
            {
                _teacherDAL.ModifyTeacher(teacher);
            }
            else
            {
                throw new NonExistentTeacherException("The table Teacher doesn't contain an entry with the id " + teacher.Id + "!");
            }
        }
    }
}
