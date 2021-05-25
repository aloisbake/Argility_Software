using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Platform.Contracts;
using UserManagement.Platform.Contracts.Models;
using UserManagement.Platform.Dal.Interfaces;

namespace UserManagement.Platform.Repo
{
    public class GroupService : IGroupService
    {
        public IGroupQueries _groupQueries;
        public GroupService(IGroupQueries groupQueries)
        {
            this._groupQueries = groupQueries;
        }
        public async Task<bool> DeleteGroup(int id)
        {
            var result = await this._groupQueries.DeleteGroup(id).ConfigureAwait(false);
            return result;
        }

        public async Task<UserGroup> GetGroupById(int id)
        {
            var result = await this._groupQueries.GetGroupById(id).ConfigureAwait(false);
            return result;
        }

        public async Task<List<UserGroup>> GetGroups()
        {
            var result = await this._groupQueries.GetGroups().ConfigureAwait(false);
            return result;
        }

        public int InsertGroup(UserGroup group)
        {
            var result = this._groupQueries.InsertGroup(group);
            return result;
        }

        public async Task<bool> UpdateGroupById(int id, UserGroup group)
        {
            var result = await this._groupQueries.UpdateGroupById(id, group).ConfigureAwait(false);
            return result;
        }
    }
}
