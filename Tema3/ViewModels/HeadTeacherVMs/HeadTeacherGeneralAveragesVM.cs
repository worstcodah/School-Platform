using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Models.EntityLayer;
using Tema3.Services.HeadTeacherServices;

namespace Tema3.ViewModels
{
    public class HeadTeacherGeneralAveragesVM : BaseVM
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
        private int _generalAverage;
        public int GeneralAverage
        {
            get
            {
                return _generalAverage;
            }
            set
            {
                _generalAverage = value;
                OnPropertyChanged(nameof(GeneralAverage));
            }
        }
        private ObservableCollection<FinalGrade> _finalGradeCollection;
        public ObservableCollection<FinalGrade> FinalGradeCollection
        {
            get
            {
                return _finalGradeCollection;
            }
            set
            {
                _finalGradeCollection = value;
                OnPropertyChanged(nameof(FinalGradeCollection));
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
                _headTeacherGeneralAveragesServices.UpdateFinalGrades();
                _headTeacherGeneralAveragesServices.UpdateGeneralAverage();
            }
        }
        private HeadTeacherGeneralAveragesServices _headTeacherGeneralAveragesServices { get; set; }
        public HeadTeacherGeneralAveragesVM(int headTeacherClassId)
        {
            HeadTeacherClassId = headTeacherClassId;
            _headTeacherGeneralAveragesServices = new HeadTeacherGeneralAveragesServices(this);
            _headTeacherGeneralAveragesServices.InitializeFields();
        }
    }
}
