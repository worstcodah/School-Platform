using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Tema3.Exceptions;
using Tema3.Models.BusinessLogicLayer;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class EditAdminServices
    {
        private EditAdminVM _editAdminVM { get; set; }
        private StudentBLL _studentBLL { get; set; }
        private TeacherBLL _teacherBLL { get; set; }
        private SubjectBLL _subjectBLL { get; set; }
        public EditAdminServices(EditAdminVM editAdminVM)
        {
            _editAdminVM = editAdminVM;
            _studentBLL = new StudentBLL();
            _teacherBLL = new TeacherBLL();
            _subjectBLL = new SubjectBLL();
        }
        public bool CanAddOrModify(object parameter)
        {
            switch (_editAdminVM.SelectedUserType)
            {
                case Constants.Constants.EntityType.STUDENT:
                    return !String.IsNullOrWhiteSpace(_editAdminVM.IdContent) && !String.IsNullOrWhiteSpace(_editAdminVM.NameContent)
                        && !String.IsNullOrWhiteSpace(_editAdminVM.IdClassContent);
                case Constants.Constants.EntityType.TEACHER:
                    return !String.IsNullOrWhiteSpace(_editAdminVM.IdContent) && !String.IsNullOrWhiteSpace(_editAdminVM.NameContent);
                case Constants.Constants.EntityType.SUBJECT:
                    return !String.IsNullOrWhiteSpace(_editAdminVM.NameContent);
                default:
                    return false;
            }
        }
        public bool CanDelete(object parameter)
        {
            switch (_editAdminVM.SelectedUserType)
            {
                case Constants.Constants.EntityType.STUDENT:
                case Constants.Constants.EntityType.TEACHER:
                case Constants.Constants.EntityType.SUBJECT:
                    return !String.IsNullOrWhiteSpace(_editAdminVM.IdContent);
                default:
                    return false;
            }
        }
        public bool IsExistentEntryException(Exception exception)
        {
            return exception is ExistentStudentException || exception is ExistentTeacherException || exception is ExistentSubjectException;
        }

        public bool IsNonExistentEntryException(Exception exception)
        {
            return exception is NonExistentStudentException || exception is NonExistentTeacherException || exception is NonExistentSubjectException;
        }
        public void AddUser(object parameter)
        {
            try
            {
                switch (_editAdminVM.SelectedUserType)
                {
                    case Constants.Constants.EntityType.STUDENT:
                        _studentBLL.AddStudent(new Student(Convert.ToInt32(_editAdminVM.IdContent), _editAdminVM.NameContent,
                            Convert.ToInt32(_editAdminVM.IdClassContent)));
                        break;
                    case Constants.Constants.EntityType.TEACHER:
                        _teacherBLL.AddTeacher(new Teacher(Convert.ToInt32(_editAdminVM.IdContent), _editAdminVM.NameContent));
                        break;
                    case Constants.Constants.EntityType.SUBJECT:
                        _subjectBLL.AddSubject(new Subject(Convert.ToInt32(_editAdminVM.IdContent), _editAdminVM.NameContent));
                        break;

                }
            }
            catch (Exception exception) when (IsExistentEntryException(exception))
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        public void DeleteUser(object parameter)
        {
            try
            {
                switch (_editAdminVM.SelectedUserType)
                {
                    case Constants.Constants.EntityType.STUDENT:
                        _studentBLL.DeleteStudent(new Student(Convert.ToInt32(_editAdminVM.IdContent), _editAdminVM.NameContent,
                            Convert.ToInt32(_editAdminVM.IdClassContent)));
                        break;
                    case Constants.Constants.EntityType.TEACHER:
                        _teacherBLL.DeleteTeacher(new Teacher(Convert.ToInt32(_editAdminVM.IdContent), _editAdminVM.NameContent));
                        break;
                    case Constants.Constants.EntityType.SUBJECT:
                        _subjectBLL.DeleteSubject(new Subject(Convert.ToInt32(_editAdminVM.IdContent), _editAdminVM.NameContent));
                        break;

                }
            }
            catch (Exception exception) when (IsNonExistentEntryException(exception))
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        public void ModifyUser(object parameter)
        {
            try
            {
                switch (_editAdminVM.SelectedUserType)
                {
                    case Constants.Constants.EntityType.STUDENT:
                        _studentBLL.ModifyStudent(new Student(Convert.ToInt32(_editAdminVM.IdContent), _editAdminVM.NameContent,
                            Convert.ToInt32(_editAdminVM.IdClassContent)));
                        break;
                    case Constants.Constants.EntityType.TEACHER:
                        _teacherBLL.ModifyTeacher(new Teacher(Convert.ToInt32(_editAdminVM.IdContent), _editAdminVM.NameContent));
                        break;
                    case Constants.Constants.EntityType.SUBJECT:
                        _subjectBLL.ModifySubject(new Subject(Convert.ToInt32(_editAdminVM.IdContent), _editAdminVM.NameContent));
                        break;

                }
            }
            catch (Exception exception) when (IsNonExistentEntryException(exception))
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
