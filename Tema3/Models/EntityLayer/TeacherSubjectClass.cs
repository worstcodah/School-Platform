using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class TeacherSubjectClass : BasePropertyChanged
    {
        private int _idClass;
        public int IdClass
        {
            get
            {
                return _idClass;
            }
            set
            {
                _idClass = value;
                OnPropertyChanged(nameof(IdClass));
            }
        }
        private int _idSubject;
        public int IdSubject
        {
            get
            {
                return _idSubject;
            }
            set
            {
                _idSubject = value;
                OnPropertyChanged(nameof(IdSubject));
            }
        }
        private int _idTeacher;
        public int IdTeacher
        {
            get
            {
                return _idTeacher;
            }
            set
            {
                _idTeacher = value;
                OnPropertyChanged(nameof(IdTeacher));
            }
        }
        private String _className;
        public String ClassName
        {
            get
            {
                return _className;
            }
            set
            {
                _className = value;
                OnPropertyChanged(nameof(ClassName));
            }
        }
        private String _subjectName;
        public String SubjectName
        {
            get
            {
                return _subjectName;
            }
            set
            {
                _subjectName = value;
                OnPropertyChanged(nameof(SubjectName));
            }
        }
        private String _teacherName;
        public String TeacherName
        {
            get
            {
                return _teacherName;
            }
            set
            {
                _teacherName = value;
                OnPropertyChanged(nameof(TeacherName));
            }
        }
        public TeacherSubjectClass(Teacher teacher, Subject subject, Class @class){
            TeacherName = teacher.Name;
            SubjectName = subject.Name;
            ClassName = @class.Name;
            IdTeacher = teacher.Id;
            IdSubject = subject.Id;
            IdClass = @class.Id;
        }
        public TeacherSubjectClass()
        {

        }
    }
}
