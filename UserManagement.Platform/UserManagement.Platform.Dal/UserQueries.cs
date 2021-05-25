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
    public class UserQueries : IUserQueries
    {
        string _connection;
        public UserQueries(string connection)
        {
            _connection = connection;
        }
        public Task<bool> DeleteUser(int ProfileUserId)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                var affectedRows = connection.Execute("Delete from ProfileUser Where ProfileUserId = @ProfileUserId", new { ProfileUserId });
                connection.Close();

                if (affectedRows > 0)
                    return Task.FromResult(true);
                else
                    return Task.FromResult(false);
            }
        }

        public async Task<ProfileUser> GetUserById(int ProfileUserId)
        {
            var userresult = new ProfileUser();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                userresult = await connection.QueryFirstOrDefaultAsync<ProfileUser>("Select * From ProfileUser WHERE ProfileUserId = @ProfileUserId",
                    new { ProfileUserId }).ConfigureAwait(false) as ProfileUser;
                connection.Close();
            }

            return userresult;
        }
   
        public async Task<List<ProfileUser>> GetUsers()
        {
            var users = new List<ProfileUser>();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                users = await connection.QueryAsync<ProfileUser>("SELECT * FROM ProfileUser") as List<ProfileUser>;
                connection.Close();
            }

            return users;
    }

        public int InsertUser(ProfileUser user)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();
                var affectedRows = connection.Execute("Insert into ProfileUser (Name ,EmailAddress ,Description , UserGroupID) values (@Name ,@EmailAddress ,@Description ,@UserGroupID)",
                    new { user.Name, user.EmailAddress, user.Description, user.UserGroupID });
                connection.Close();
                return affectedRows;
            }
        }

        public Task<bool> UpdateUserById(int id, ProfileUser user)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();
                var affectedRows = connection.Execute("Update ProfileUser set Name = @Name , Description = @Description, EmailAddress = @EmailAddress, UserGroupID = @UserGroupID",
                    new { user.Name, user.Description, user.EmailAddress, user.UserGroupID });
                connection.Close();

                if (affectedRows > 0)
                    return Task.FromResult(true);
                else
                    return Task.FromResult(false);
            }
        }
    }
}
