using System;
using System.Collections.Generic;
using System.Text;
using Tema3.Commands;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.Navigation;
using Tema3.Services;

namespace Tema3.ViewModels
{
    public class LoginVM : BaseVM
    {
        public LoginVM()
        {

        }
        private String _loginButtonLabel;
        public String LoginButtonLabel
        {
            get
            {
                return _loginButtonLabel;
            }
            set
            {
                _loginButtonLabel = value;
            }
        }

        private String _userNameLabel;
        public String UserNameLabel
        {
            get
            {
                return _userNameLabel;
            }
            set
            {
                _userNameLabel = value;
            }
        }

        private String _passwordLabel;
        public String PasswordLabel
        {
            get
            {
                return _passwordLabel;
            }
            set
            {
                _passwordLabel = value;
            }
        }

        private String _userNameContent;
        public String UserNameContent
        {
            get
            {
                return _userNameContent;
            }
            set
            {
                _userNameContent = value;
            }
        }

        private readonly ViewNavigation _viewNavigation;

        public RelayCommand LoginCommand { get; set; }
        private LoginServices _loginServices { get; set; }
        public LoginVM(ViewNavigation viewNavigation)
        {
            _viewNavigation = viewNavigation;
            _loginServices = new LoginServices(this, _viewNavigation);
            UserNameLabel = "Username";
            PasswordLabel = "Password";
            LoginButtonLabel = "Login";
            LoginCommand = new RelayCommand(_loginServices.LoginAction, _loginServices.CanLogin);
        }
    }
}
