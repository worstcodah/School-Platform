using System;
using System.Collections.Generic;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class HeadTeacher : Teacher
    {
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
        public HeadTeacher(int id, String name, int idClass) : base(id, name)
        {
            this.IdClass = idClass;
        }
        public HeadTeacher()
        {

        }
    }
}
