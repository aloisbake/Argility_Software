using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Platform.Contracts.Models
{
    public class UserPassword : ProfileUser
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
