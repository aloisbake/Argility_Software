using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Platform.Contracts.Models
{
    public class ProfileUser
    {
        public int ProfileUserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }       
        public string EmailAddress { get; set; }
        public int IsActive { get; set; }
        public int UserGroupID { get; set; }
    }
}
