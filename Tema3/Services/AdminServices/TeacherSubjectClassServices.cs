using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.ViewModels;

namespace Tema3.Services
{
    public class TeacherSubjectClassServices
    {
        private TeacherSubjectClassVM _teacherSubjectClassVM { get; set; }
        public TeacherSubjectClassServices(TeacherSubjectClassVM teacherSubjectVM)
        {
            _subjectDAL = new SubjectDAL();
            _teacherDAL = new TeacherDAL();
            _classDAL = new ClassDAL();
            _teacherSubjectClassDAL = new TeacherSubjectClassDAL();
            _teacherSubjectClassVM = teacherSubjectVM;
        }
        private SubjectDAL _subjectDAL { get; set; }
        private TeacherDAL _teacherDAL { get; set; }
        private ClassDAL _classDAL { get; set; }
        private TeacherSubjectClassDAL _teacherSubjectClassDAL { get; set; }

        public void InitializeCollections()
        {
            _teacherSubjectClassVM.TeacherSubjectClassCollection = new ObservableCollection<TeacherSubjectClass>();
            _teacherSubjectClassVM.TeacherSubjectClassCollection = _teacherSubjectClassDAL.GetAllTeacherSubjectClass();
            _teacherSubjectClassVM.TeacherCollection = _teacherDAL.GetAllTeachers();
            _teacherSubjectClassVM.SubjectCollection = _subjectDAL.GetAllSubjects();
            _teacherSubjectClassVM.ClassCollection = _classDAL.GetAllClasses();
        }
        public void LinkTogether(object parameter)
        {
            var newJoinEntity = new TeacherSubjectClass(_teacherSubjectClassVM.SelectedTeacher, _teacherSubjectClassVM.SelectedSubject, _teacherSubjectClassVM.SelectedClass);
            if (!_teacherSubjectClassDAL.LinkExists(newJoinEntity))
            {
                _teacherSubjectClassDAL.InsertInJoinTable(newJoinEntity);
                _teacherSubjectClassVM.TeacherSubjectClassCollection.Add(newJoinEntity);
            }
            else
            {
                _teacherSubjectClassDAL.UpdateJoinTable(newJoinEntity);
                _teacherSubjectClassVM.TeacherSubjectClassCollection = _teacherSubjectClassDAL.GetAllTeacherSubjectClass();
            }
        }
        public bool CanLink(object parameter)
        {
            return _teacherSubjectClassVM.SelectedClass != null && _teacherSubjectClassVM.SelectedTeacher != null && _teacherSubjectClassVM.SelectedSubject != null;
        }
    }
}
