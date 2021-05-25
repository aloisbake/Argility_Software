﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Platform.Contracts.Models
{
    public class UserGroup
    {
        public int UserGroupID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
