using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Models.EntityLayer;
using Tema3.Services.HeadTeacherServices;

namespace Tema3.ViewModels
{
    public class HeadTeacherExpelVM : BaseVM
    {
        private ObservableCollection<Student> _expelleeCollection;
        public ObservableCollection<Student> ExpelleeCollection
        {
            get
            {
                return _expelleeCollection;
            }
            set
            {
                _expelleeCollection = value;
                OnPropertyChanged(nameof(ExpelleeCollection));
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
        private HeadTeacherExpelServices _headTeacherExpelServices { get; set; }
        public HeadTeacherExpelVM(int headTeacherClassId)
        {
            _headTeacherExpelServices = new HeadTeacherExpelServices(this);
            HeadTeacherClassId = headTeacherClassId;
            _headTeacherExpelServices.InitializeFields();
        }
    }
}
