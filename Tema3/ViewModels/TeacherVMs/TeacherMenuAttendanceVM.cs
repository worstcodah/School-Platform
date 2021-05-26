using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Commands;
using Tema3.Models.EntityLayer;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class TeacherMenuAttendanceVM : BaseVM
    {
        private ObservableCollection<Absence> _absenceCollection;
        public ObservableCollection<Absence> AbsenceCollection
        {
            get
            {
                return _absenceCollection;
            }
            set
            {
                _absenceCollection = value;
                OnPropertyChanged(nameof(AbsenceCollection));
            }
        }
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
        private ObservableCollection<SubjectClass> _subjectClassCollection;
        public ObservableCollection<SubjectClass> SubjectClassCollection
        {
            get
            {
                return _subjectClassCollection;
            }
            set
            {
                _subjectClassCollection = value;
                OnPropertyChanged(nameof(SubjectClassCollection));
            }
        }
        private int _loggedTeacherId;
        public int LoggedTeacherId
        {
            get
            {
                return _loggedTeacherId;
            }
            set
            {
                _loggedTeacherId = value;
                OnPropertyChanged(nameof(LoggedTeacherId));
            }
        }
        private String _absenceDate;
        public String AbsenceDate
        {
            get
            {
                return _absenceDate;
            }
            set
            {
                _absenceDate = value;
                OnPropertyChanged(AbsenceDate);
            }
        }
        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }
        private SubjectClass _selectedSubjectClass;
        public SubjectClass SelectedSubjectClass
        {
            get
            {
                return _selectedSubjectClass;
            }
            set
            {
                _selectedSubjectClass = value;
                OnPropertyChanged(nameof(SelectedSubjectClass));
            }
        }
        private Semester _selectedSemester;
        public Semester SelectedSemester
        {
            get
            {
                return _selectedSemester;
            }
            set
            {
                _selectedSemester = value;
                OnPropertyChanged(nameof(SelectedSemester));
            }
        }
        private List<Semester> _semesterCollection;
        public List<Semester> SemesterCollection
        {
            get
            {
                return _semesterCollection;
            }
            set
            {
                _semesterCollection = value;
                OnPropertyChanged(nameof(SemesterCollection));
            }
        }
        public RelayCommand MarkAbsenceCommand { get; set; }
        public RelayCommand MotivateAbsencesCommand { get; set; }
        private TeacherMenuAttendanceServices _teacherMenuAttendanceServices { get; set; } 
        public TeacherMenuAttendanceVM(int loggedTeacherId)
        {
            _teacherMenuAttendanceServices = new TeacherMenuAttendanceServices(this);
            LoggedTeacherId = loggedTeacherId;
            _teacherMenuAttendanceServices.InitializeFields();
        }
    }
}
