using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tema3.ViewModels
{
    public class BaseVM : INotifyPropertyChanged, IDisposable
    {
        public BaseVM()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Dispose() { }
    }
}
