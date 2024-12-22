﻿using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models.Accounts
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}