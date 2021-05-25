using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Platform.Contracts.Models;
using UserManagement.Platform.Dal.Interfaces;

namespace UserManagement.Platform.Dal
{
    public class GroupQueries : IGroupQueries
    {
        string _connection;
        public GroupQueries(string connection)
        {
            this._connection = connection;
        }
        public Task<bool> DeleteGroup(int UserGroupId)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                var affectedRows = connection.Execute("Delete from UserGroup Where UserGroupId = @UserGroupId", new { UserGroupId });
                connection.Close();

                if (affectedRows > 0)
                    return Task.FromResult(true);
                else
                    return Task.FromResult(false);
            }
        }

        public async Task<UserGroup> GetGroupById(int UserGroupId)
        {
            var groupresult = new UserGroup();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                groupresult = await connection.QueryFirstOrDefaultAsync<UserGroup>("Select * From UserGroup WHERE UserGroupId = @UserGroupId",
                    new { UserGroupId }).ConfigureAwait(false);
                connection.Close();
            }

            return groupresult;
        }

        public async Task<List<UserGroup>> GetGroups()
        {
            var groups = new List<UserGroup>();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                groups = await connection.QueryAsync<UserGroup>("Select * FROM UserGroup") as List<UserGroup>;
                connection.Close();
            }

            return groups;
        }

        public int InsertGroup(UserGroup group)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();
                var affectedRows = connection.Execute("Insert into UserGroup (Name , Description , IsActive) values (@Name ,@Description ,@IsActive)",
                    new { group.Name, group.Description, group.IsActive });
                connection.Close();
                return affectedRows;
            }
        }

        public Task<bool> UpdateGroupById(int id, UserGroup group)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();
                var affectedRows = connection.Execute("Update UserGroup set Name = @Name , Description = @Description, IsActive = @IsActive",
                    new { group.Name, group.Description, group.IsActive });
                connection.Close();

                if (affectedRows > 0)
                    return Task.FromResult(true);
                else
                    return Task.FromResult(false);
            }
        }
    }
}
