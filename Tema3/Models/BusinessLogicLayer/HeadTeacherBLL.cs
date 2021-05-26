using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Exceptions;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.Models.BusinessLogicLayer
{
    public class HeadTeacherBLL
    {
        private HeadTeacherDAL _headTeacherDAL { get; set; }
        public HeadTeacherBLL()
        {
            _headTeacherDAL = new HeadTeacherDAL();
        }
        public HeadTeacher GetClassHeadTeacher(Class @class)
        {
            return _headTeacherDAL.GetClassHeadTeacher(@class);
        }
        public void UpdateClassHeadTeacher(Class @class, Teacher teacher)
        {
            if (!_headTeacherDAL.IsAlreadyHeadTeacher(teacher.Id))
            {
                _headTeacherDAL.UpdateClassHeadTeacher(@class, teacher);
            }
            else
            {
                throw new AlreadyHeadTeacherException("The teacher with id " + teacher.Id + " (" + teacher.Name + ") is already a headteacher !");
            }
        }
        public bool IsAlreadyHeadTeacher(int teacherId)
        {
            return _headTeacherDAL.IsAlreadyHeadTeacher(teacherId);
        }
    }
}
