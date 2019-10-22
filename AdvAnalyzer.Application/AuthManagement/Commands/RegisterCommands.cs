using AdvAnalyzer.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAnalyzer.Application.AuthManagement.Commands
{
    public class RegisterCommand : ICommand
    {
        public RegisterCommand(
            string email,
            string phoneNumber,
            string login,
            string password,
            string confirmPassword)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            Login = login;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }
    }
}
