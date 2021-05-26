using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class Teacher : BasePropertyChanged
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private String _name;
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public Teacher(int id, String name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Teacher()
        {

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
