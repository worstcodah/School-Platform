using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Commands;
using Tema3.Models.EntityLayer;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class HeadTeacherAbsencesVM : BaseVM
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
                _headTeacherAbsencesServices.UpdateAbsenceCollection();
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
        public RelayCommand MotivateAbsencesCommand { get; set; }
        private HeadTeacherAbsencesServices _headTeacherAbsencesServices { get; set; }
        public HeadTeacherAbsencesVM(int headTeacherClassId)
        {
            HeadTeacherClassId = headTeacherClassId;
            _headTeacherAbsencesServices = new HeadTeacherAbsencesServices(this);
            _headTeacherAbsencesServices.InitializeFields();
        }
    }
}
