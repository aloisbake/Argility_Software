using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UserManagement.Platform.Contracts;
using UserManagement.Platform.Contracts.Models;

namespace UserManagement.Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.userService.GetUsers().ConfigureAwait(false);
                return this.Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Users/GetUserById/5
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var result = await this.userService.GetUserById(id).ConfigureAwait(false);
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST: api/Users/Post
        [HttpPost]
        public void Post([FromBody] ProfileUser user)
        {
            try
            {
                var result = this.userService.InsertUser(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Users/Patch
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] ProfileUser user)
        {
            try
            {
                var result = await this.userService.UpdateUserById(id, user).ConfigureAwait(false);
                return this.Ok(result);
            }
            catch (Exception)
            {
                throw;
            }

        }

        // DELETE: api/Users/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this.userService.DeleteUser(id).ConfigureAwait(false);
                return this.Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
