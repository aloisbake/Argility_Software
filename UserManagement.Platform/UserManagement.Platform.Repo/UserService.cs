using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Platform.Contracts;
using UserManagement.Platform.Contracts.Models;
using UserManagement.Platform.Dal.Interfaces;

namespace UserManagement.Platform.Repo
{
    public class UserService : IUserService
    {
        public IUserQueries _userQueries;
        public UserService(IUserQueries userQueries)
        {
            this._userQueries = userQueries;
        }
        public async Task<bool> DeleteUser(int id)
        {
            var result = await this._userQueries.DeleteUser(id).ConfigureAwait(false);
            return result;
        }

        public async Task<ProfileUser> GetUserById(int id)
        {
            var result = await this._userQueries.GetUserById(id).ConfigureAwait(false);
            return result;
        }

        public async Task<List<ProfileUser>> GetUsers()
        {
            var result = await this._userQueries.GetUsers().ConfigureAwait(false);
            return result;
        }

        public int InsertUser(ProfileUser user)
        {
            var result = this._userQueries.InsertUser(user);
            return result;
        }

        public async Task<bool> UpdateUserById(int id, ProfileUser user)
        {
            var result = await this._userQueries.UpdateUserById(id, user).ConfigureAwait(false);
            return result;
        }
    }
}
