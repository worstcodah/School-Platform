using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Exceptions;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;

namespace Tema3.Models.BusinessLogicLayer
{
    public class StudentBLL
    {
        private StudentDAL _studentDAL { get; set; }
        public StudentBLL()
        {
            _studentDAL = new StudentDAL();
        }
        public ObservableCollection<Student> GetAllStudents()
        {
            return _studentDAL.GetAllStudents();
        }
        public ObservableCollection<Student> GetAllStudentsFromClass(Class @class)
        {
            return _studentDAL.GetAllStudentsFromClass(@class);
        }
        public void RemoveStudentFromClass(Student student)
        {
            _studentDAL.RemoveStudentFromClass(student);
        }
        public ObservableCollection<Student> GetStudentsForTeacher(int teacherId)
        {
           return _studentDAL.GetStudentsForTeacher(teacherId);
        }

        public void AddStudent(Student student)
        {
            if (!_studentDAL.StudentExists(student))
            {
                _studentDAL.AddStudent(student);
            }
            else
            {
                throw new ExistentStudentException("The Student table already contains an entry with the id " + student.Id + "!");
            }
        }

        public void DeleteStudent(Student student)
        {
            if (_studentDAL.StudentExists(student))
            {
                _studentDAL.DeleteStudent(student);
            }
            else
            {
                throw new NonExistentStudentException("The Student table doesn't contain an entry with the id" + student.Id + "!");
            }
        }

        public void ModifyStudent(Student student)
        {
            if (_studentDAL.StudentExists(student))
            {
                _studentDAL.ModifyStudent(student);
            }
            else
            {
                throw new NonExistentStudentException("The Student table doesn't contain an entry with the id" + student.Id + "!");
            }
        }
        public ObservableCollection<Student> GetStudentsByClassId(int classId)
        {
            return _studentDAL.GetStudentsByClassId(classId);
        }
        public String GetClassNameByStudentId(int studentId)
        {
            return _studentDAL.GetClassNameByStudentId(studentId);
        }
        public String GetStudentNameByStudentId(int studentId)
        {
            return _studentDAL.GetStudentNameByStudentId(studentId);
        }
    }
}
