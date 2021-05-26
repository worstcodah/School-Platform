using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Commands;
using Tema3.Models.EntityLayer;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class HeadTeacherHierarchyVM : BaseVM
    {
        private ObservableCollection<StudentGeneralAverage> _studentGeneralAverageCollection;
        public ObservableCollection<StudentGeneralAverage> StudentGeneralAverageCollection
        {
            get
            {
                return _studentGeneralAverageCollection;
            }
            set
            {
                _studentGeneralAverageCollection = value;
                OnPropertyChanged(nameof(StudentGeneralAverageCollection));
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
        public RelayCommand ShowHierarchyCommand { get; set; } 
        public RelayCommand ShowRankingsCommand { get; set; }
        private HeadTeacherHierarchyServices _headTeacherHierarchyServices { get; set; }
        public HeadTeacherHierarchyVM(int headTeacherClassId)
        {
            HeadTeacherClassId = headTeacherClassId;
            _headTeacherHierarchyServices = new HeadTeacherHierarchyServices(this);
            _headTeacherHierarchyServices.InitializeFields();
        }
    }
}
