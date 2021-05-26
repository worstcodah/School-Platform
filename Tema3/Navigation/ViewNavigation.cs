using System;
using System.Collections.Generic;
using System.Text;
using Tema3.ViewModels;

namespace Tema3.Navigation
{
    public class ViewNavigation
    {
        public event Action CurrentViewModelChanged;
        private BaseVM _currentVM;
        public BaseVM CurrentVM
        {
            get => _currentVM;
            set
            {
                _currentVM?.Dispose();
                _currentVM = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
