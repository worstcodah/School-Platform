using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tema3.Models.EntityLayer;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class HeadTeacherRepeaterVM : BaseVM
    {
        private ObservableCollection<Failer> _repeaterCollection;
        public ObservableCollection<Failer> RepeaterCollection
        {
            get
            {
                return _repeaterCollection;
            }
            set
            {
                _repeaterCollection = value;
                OnPropertyChanged(nameof(RepeaterCollection));
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
        private HeadTeacherRepeaterServices _headTeacherRepeaterServices { get; set; }
        public HeadTeacherRepeaterVM(int headTeacherClassId)
        {
            HeadTeacherClassId = headTeacherClassId;
            _headTeacherRepeaterServices = new HeadTeacherRepeaterServices(this);
            _headTeacherRepeaterServices.InitializeFields();
        }
    }
}
