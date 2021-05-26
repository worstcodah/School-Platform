using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Tema3.Commands;
using Tema3.Services;
using static Tema3.Constants.Constants;

namespace Tema3.ViewModels
{
    public class EditAdminVM : BaseVM
    {
        private List<String> _userTypes;
        public List<String> UserTypes
        {
            get
            {
                return _userTypes;
            }
            set
            {
                _userTypes = value;
                OnPropertyChanged(nameof(UserTypes));
            }
        }

        private EntityType _selectedUserType;
        public EntityType SelectedUserType
        {
            get
            {
                return _selectedUserType;
            }
            set
            {
                _selectedUserType = value;
                OnPropertyChanged(nameof(SelectedUserType));
            }

        }
        private String _idContent;
        public String IdContent
        {
            get
            {
                return _idContent;
            }
            set
            {
                _idContent = value;
                OnPropertyChanged(nameof(IdContent));
            }
        }
        private String _nameContent;
        public String NameContent
        {
            get
            {
                return _nameContent;
            }
            set
            {
                _nameContent = value;
                OnPropertyChanged(nameof(NameContent));
            }
        }
        private String _idClassContent;
        public String IdClassContent
        {
            get
            {
                return _idClassContent;
            }
            set
            {
                _idClassContent = value;
                OnPropertyChanged(nameof(IdClassContent));
            }
        }
        public RelayCommand AddUserToDB { get; set; }
        public RelayCommand ModifyUserFromDB { get; set; }
        public RelayCommand DeleteUserFromDB { get; set; }
        private EditAdminServices _editAdminServices { get; set; }
        public EditAdminVM()
        {
            _editAdminServices = new EditAdminServices(this);
            AddUserTypes();
            AddUserToDB = new RelayCommand(_editAdminServices.AddUser, _editAdminServices.CanAddOrModify);
            DeleteUserFromDB = new RelayCommand(_editAdminServices.DeleteUser, _editAdminServices.CanDelete);
            ModifyUserFromDB = new RelayCommand(_editAdminServices.ModifyUser, _editAdminServices.CanAddOrModify);
        }
        public void AddUserTypes()
        {
            UserTypes = new List<String>();
            UserTypes.Add(EntityType.STUDENT.ToString());
            UserTypes.Add(EntityType.TEACHER.ToString());
            UserTypes.Add(EntityType.SUBJECT.ToString());
        }
    }
}
