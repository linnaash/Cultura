﻿using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models.Accounts
{
    public class UpdateRequest
    {
        private string _password;
        private string _confirmPassword;
        private string _role;
        private string _email;

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [EnumDataType(typeof(Role))]
        public string Role
        {
            get => _role;
            set => _role = replaceEmptyWithNull(value);
        }

        [EmailAddress]
        public string Email
        {
            get => _email;
            set => _email = replaceEmptyWithNull(value);
        }
        [MinLength(6)]
        public string Password
        {
            get => _password;
            set => _password = replaceEmptyWithNull(value);
        }
        [Compare("Password")]
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => _confirmPassword = replaceEmptyWithNull(value);
        }
        private string replaceEmptyWithNull(string value)
        {
            //replace empty string with null to male field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}
