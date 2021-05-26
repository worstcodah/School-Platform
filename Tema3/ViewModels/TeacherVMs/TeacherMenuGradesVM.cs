using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Commands;
using Tema3.Models.EntityLayer;
using Tema3.Services;


namespace Tema3.ViewModels
{
    public class  TeacherMenuGradesVM : BaseVM
    {
        private ObservableCollection<GradeCollectionItem> _gradeCollection;
        public ObservableCollection<GradeCollectionItem> GradeCollection
        {
            get
            {
                return _gradeCollection;
            }
            set
            {
                _gradeCollection = value;
                OnPropertyChanged(nameof(GradeCollection));
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
        private String _gradeValue;
        public String GradeValue
        {
            get
            {
                return _gradeValue;
            }
            set
            {
                _gradeValue = value;
                OnPropertyChanged(nameof(GradeValue));
            }
        }
        private List<bool> _isThesisGradeChoices;
        public List<bool> IsThesisGradeChoices
        {
            get
            {
                return _isThesisGradeChoices;
            }
            set
            {
                _isThesisGradeChoices = value;
                OnPropertyChanged(nameof(IsThesisGradeChoices));
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
        private bool _selectedThesisGradeChoice;
        public bool SelectedThesisGradeChoice
        {
            get
            {
                return _selectedThesisGradeChoice;

            }
            set
            {
                _selectedThesisGradeChoice = value;
                OnPropertyChanged(nameof(SelectedThesisGradeChoice));
            }
        }
        private String _gradeDate;
        public String GradeDate
        {
            get
            {
                return _gradeDate;
            }
            set
            {
                _gradeDate = value;
                OnPropertyChanged(nameof(GradeDate));
            }
        }
        private TeacherMenuGradeServices _teacherMenuGradeServices { get; set; }
        public RelayCommand DeleteGradesCommand { get; set; }
        public RelayCommand AddGradeCommand { get; set; }
        public TeacherMenuGradesVM(int loggedTeacherId)
        {
            _teacherMenuGradeServices = new TeacherMenuGradeServices(this);
            LoggedTeacherId = loggedTeacherId;
            _teacherMenuGradeServices.InitializeFields();
        }
    }
}
