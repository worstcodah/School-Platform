using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using Tema3.Commands;
using Tema3.Models.EntityLayer;
using Tema3.Services;

namespace Tema3.ViewModels
{

    public class HeadTeacherAttendanceVM : BaseVM
    {
        private ObservableCollection<String> _choiceCollection;
        public ObservableCollection<String> ChoiceCollection
        {
            get
            {
                return _choiceCollection;
            }
            set
            {
                _choiceCollection = value;
                OnPropertyChanged(nameof(ChoiceCollection));
            }
        }
        private String _selectedChoice;
        public String SelectedChoice
        {
            get
            {
                return _selectedChoice;
            }
            set
            {
                _selectedChoice = value;
                OnPropertyChanged(nameof(SelectedChoice));
                if (_headTeacherAttendanceServices.IsStudentSelected())
                {
                    _headTeacherAttendanceServices.SetVisible();
                    _headTeacherAttendanceServices.InitializeStudentCollection();
                }
                else
                {
                    _headTeacherAttendanceServices.SetInvisible();
                }
            }
        }
        private ObservableCollection<String> _absenceTypeCollection;
        public ObservableCollection<String> AbsenceTypeCollection
        {
            get
            {
                return _absenceTypeCollection;
            }
            set
            {
                _absenceTypeCollection = value;
                OnPropertyChanged(nameof(AbsenceTypeCollection));
            }
        }
        private String _selectedAbsenceType;
        public String SelectedAbsenceType
        {
            get
            {
                return _selectedAbsenceType;
            }
            set
            {
                _selectedAbsenceType = value;
                OnPropertyChanged(nameof(SelectedAbsenceType));
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
        private Visibility _studentBoxVisibility;
        public Visibility StudentBoxVisibility
        {
            get
            {
                return _studentBoxVisibility;
            }
            set
            {
                _studentBoxVisibility = value;
                OnPropertyChanged(nameof(StudentBoxVisibility));
            }
        }
        private int _headTeacherClassId;
        public int HeadTeacherClassId
        {
            get
            {
                return _headTeacherClassId;
            }
            set
            {
                _headTeacherClassId = value;
                OnPropertyChanged(nameof(HeadTeacherClassId));
            }
        }
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
        private int _totalNoAbsences;
        public int TotalNoAbsences
        {
            get
            {
                return _totalNoAbsences;
            }
            set
            {
                _totalNoAbsences = value;
                OnPropertyChanged(nameof(TotalNoAbsences));
            }
        }
        private HeadTeacherAttendanceServices _headTeacherAttendanceServices { get; set; }
        public RelayCommand UpdateAbsencesCommand { get; set; }
        public HeadTeacherAttendanceVM(int headTeacherClassId)
        {
            _headTeacherAttendanceServices = new HeadTeacherAttendanceServices(this);
            _headTeacherClassId = headTeacherClassId;
            _headTeacherAttendanceServices.InitializeFields();
        }
    }
}
