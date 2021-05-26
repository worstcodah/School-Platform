using System;
using System.Collections.Generic;
using System.Text;
using static Tema3.Constants.Constants;

namespace Tema3.Models.EntityLayer
{
    public class User : BasePropertyChanged
    {
        public User( String userName, String password)
        {
            
            UserName = userName;
            Password = password;
            
        }
        public User()
        {

        }
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
        private String _userName;
        public String UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        private String _password;
        public String Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private EntityType _userType;
        public EntityType UserType
        {
            get
            {
                return _userType;
            }
            set
            {
                _userType = value;
                OnPropertyChanged(nameof(UserType));
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is User))
            {
                return false;
            }
            return (obj as User).UserName == this.UserName && (obj as User).Password == this.Password;
        }
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
