using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Commands;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class StudentClassVM : BaseVM
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
        private ObservableCollection<Class> _classColection;
        public ObservableCollection<Class> ClassCollection
        {
            get
            {
                return _classColection;
            }
            set
            {
                _classColection = value;
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

                _studentClassServices.GetStudentsFromSelectedClass(_selectedClass);
                _studentClassServices.GetClassHeadTeacher(_selectedClass);

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
        private HeadTeacher _selectedClassHeadTeacher;
        public HeadTeacher SelectedClassHeadTeacher
        {
            get
            {
                return _selectedClassHeadTeacher;
            }
            set
            {
                _selectedClassHeadTeacher = value;
                OnPropertyChanged(nameof(SelectedClassHeadTeacher));
            }
        }
        private StudentClassServices _studentClassServices { get; set; }
        public RelayCommand LinkFieldsCommand { get; set; }
        public RelayCommand RemoveFromClassCommand { get; set; }

        public StudentClassVM()
        {
            _studentClassServices = new StudentClassServices(this);
            _studentClassServices.InitializeFields();
        }
    }
}
