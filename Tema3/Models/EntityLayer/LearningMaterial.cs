using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tema3.Models.EntityLayer
{
    public class LearningMaterial : BasePropertyChanged
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
        private String _filePath;
        public String FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }
        public LearningMaterial()
        {

        }
        public LearningMaterial( String filePath)
        {
            FilePath = filePath;
        }
    }
}
