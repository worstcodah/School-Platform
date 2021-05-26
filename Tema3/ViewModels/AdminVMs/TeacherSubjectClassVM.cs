using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Commands;
using Tema3.Models.EntityLayer;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class TeacherSubjectClassVM : BaseVM
    {
        private ObservableCollection<TeacherSubjectClass> _teacherSubjectClassCollection;
        public ObservableCollection<TeacherSubjectClass> TeacherSubjectClassCollection
        {
            get
            {
                return _teacherSubjectClassCollection;
            }
            set
            {
                _teacherSubjectClassCollection = value;
                OnPropertyChanged(nameof(TeacherSubjectClassCollection));
            }
        }
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
            }
        }
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
            }
        }
        private ObservableCollection<Class> _classCollection;
        public ObservableCollection<Class> ClassCollection
        {
            get
            {
                return _classCollection;
            }
            set
            {
                _classCollection = value;
            }
        }

        private Teacher _selectedTeacher;
        public Teacher SelectedTeacher
        {
            get
            {
                return _selectedTeacher;
            }
            set
            {
                _selectedTeacher = value;
                OnPropertyChanged(nameof(SelectedTeacher));
            }
        }
        private Subject _selectedSubject;
        public Subject SelectedSubject
        {
            get
            {
                return _selectedSubject;
            }
            set
            {
                _selectedSubject = value;
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }
        private Class _selectedClass;
        public Class SelectedClass
        {
            get
            {
                return _selectedClass;
            }
            set
            {
                _selectedClass = value;
                OnPropertyChanged(nameof(SelectedClass));
            }
        }

        public RelayCommand LinkFieldsCommand { get; set; } 
        private TeacherSubjectClassServices _teacherSubjectClassServices { get; set; }
        public TeacherSubjectClassVM()
        {
            _teacherSubjectClassServices = new TeacherSubjectClassServices(this);
            _teacherSubjectClassServices.InitializeCollections();
            LinkFieldsCommand = new RelayCommand(_teacherSubjectClassServices.LinkTogether, _teacherSubjectClassServices.CanLink);
        }
    }
}
