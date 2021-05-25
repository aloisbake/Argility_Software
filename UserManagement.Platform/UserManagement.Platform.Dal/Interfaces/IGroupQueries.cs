using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Platform.Contracts.Models;

namespace UserManagement.Platform.Dal.Interfaces
{
    public interface IGroupQueries
    {
        Task<List<UserGroup>> GetGroups();
        Task<UserGroup> GetGroupById(int id);
        Task<bool> UpdateGroupById(int id, UserGroup group);
        int InsertGroup(UserGroup group);
        Task<bool> DeleteGroup(int id);
    }
}
