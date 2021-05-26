using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class Student : BasePropertyChanged
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
        private int _idClass;
        public int IdClass
        {
            get
            {
                return _idClass;
            }
            set
            {
                _idClass = value;
                OnPropertyChanged(nameof(IdClass));
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

        public Student(int id, String name, int idClass)
        {
            this.Id = id;
            this.Name = name;
            this.IdClass = idClass;
        }
        public Student()
        {
           
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
