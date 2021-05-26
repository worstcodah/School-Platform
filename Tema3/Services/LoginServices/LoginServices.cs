using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Tema3.Models.DataAccessLayer;
using Tema3.Models.EntityLayer;
using Tema3.Navigation;
using Tema3.ViewModels;
using static Tema3.Constants.Constants;

namespace Tema3.Services
{
    public class LoginServices
    {
        private LoginVM loginVM { get; set; }
        private UserDAL userDAL { get; set; }
        private readonly ViewNavigation viewNavigation;
        public LoginServices(LoginVM loginVM, ViewNavigation viewNavigation)
        {
            this.loginVM = loginVM;
            userDAL = new UserDAL();
            this.viewNavigation = viewNavigation;
        }

        public bool CanLogin(object parameter)
        {
            return !String.IsNullOrWhiteSpace((parameter as PasswordBox).Password) && !String.IsNullOrWhiteSpace(loginVM.UserNameContent);
        }

        public void UpdateView(User user)
        {
            switch (user.UserType)
            {
                case EntityType.ADMIN:
                    viewNavigation.CurrentVM = new AdminVM(viewNavigation);
                    break;
                case EntityType.STUDENT:
                    viewNavigation.CurrentVM = new StudentVM(viewNavigation, user.Id);
                    break;
                case EntityType.TEACHER:
                    viewNavigation.CurrentVM = new TeacherVM(viewNavigation, user.Id);
                    break;
            }
        }
        public void LoginAction(object parameter)
        {
            var user = new User(loginVM.UserNameContent, (parameter as PasswordBox).Password);
            if (userDAL.UserExists(user))
            {
                MessageBox.Show("You have been succesfully logged in !", "Succesful login", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateView(user);
            }
            else
            {
                MessageBox.Show("Invalid credentials !", "Login error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
