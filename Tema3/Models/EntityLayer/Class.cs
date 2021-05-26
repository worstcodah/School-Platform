using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class Class : BasePropertyChanged
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
        private int _idYear;
        public int IdYear
        {
            get
            {
                return _idYear;
            }
            set
            {
                _idYear = value;
                OnPropertyChanged(nameof(IdYear));
            }
        }
        private int _idSpecialization;
        public int IdSpecialization
        {
            get
            {
                return _idSpecialization;
            }
            set
            {
                _idSpecialization = value;
                OnPropertyChanged(nameof(IdSpecialization));
            }
        }
        private int _idHeadTeacher;
        public int IdHeadTeacher
        {
            get
            {
                return _idHeadTeacher;
            }
            set
            {
                _idHeadTeacher = value;
                OnPropertyChanged(nameof(IdHeadTeacher));
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

        public override string ToString()
        {
            return Name;
        }

    }
}
