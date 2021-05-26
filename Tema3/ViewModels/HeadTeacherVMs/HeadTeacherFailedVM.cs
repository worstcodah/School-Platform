using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Models.EntityLayer;
using Tema3.Services.HeadTeacherServices;

namespace Tema3.ViewModels
{
    public class HeadTeacherFailedVM : BaseVM
    {
        private ObservableCollection<Failer> _failerCollection;
        public ObservableCollection<Failer> FailerCollection
        {
            get
            {
                return _failerCollection;
            }
            set
            {
                _failerCollection = value;
                OnPropertyChanged(nameof(FailerCollection));
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
        private HeadTeacherFailedServices _headTeacherFailedServices { get; set; }
        public HeadTeacherFailedVM(int headTeacherClassId)
        {
            HeadTeacherClassId = headTeacherClassId;
            _headTeacherFailedServices = new HeadTeacherFailedServices(this);
            _headTeacherFailedServices.InitializeFields();
        }
    }
}
