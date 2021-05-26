using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class BasePropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
