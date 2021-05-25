﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Platform.Contracts.Models;

namespace UserManagement.Platform.Dal.Interfaces
{
    public interface IUserQueries
    {
        Task<List<ProfileUser>> GetUsers();
        Task<ProfileUser> GetUserById(int id);
        Task<bool> UpdateUserById(int id, ProfileUser user);
        int InsertUser(ProfileUser user);
        Task<bool> DeleteUser(int id);
    }
}
