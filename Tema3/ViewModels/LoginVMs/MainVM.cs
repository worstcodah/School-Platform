using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Navigation;

namespace Tema3.ViewModels
{
    public class MainVM : BaseVM
    {
        private  ViewNavigation _viewNavigation { get; set; }
        public BaseVM CurrentVM => _viewNavigation.CurrentVM;

        public MainVM()
        {
            _viewNavigation = new ViewNavigation();
            _viewNavigation.CurrentVM = new LoginVM(_viewNavigation);
            _viewNavigation.CurrentViewModelChanged += OnCurrentVMChanged;
        }

        private void OnCurrentVMChanged()
        {
            OnPropertyChanged(nameof(CurrentVM));
        }
    }
}
