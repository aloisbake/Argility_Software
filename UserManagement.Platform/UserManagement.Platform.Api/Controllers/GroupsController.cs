using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Platform.Contracts;
using UserManagement.Platform.Contracts.Models;

namespace UserManagement.Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService groupService;

        public GroupsController(IGroupService dealerService)
        {
            this.groupService = dealerService;
        }
        // GET: api/Groups
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.groupService.GetGroups().ConfigureAwait(false);
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: api/GetGroupById/5
        [HttpGet("{id}", Name = "GetGroupById")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            try
            {
                var result = await this.groupService.GetGroupById(id).ConfigureAwait(false);
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST: api/Groups
        [HttpPost]
        public void Post([FromBody] UserGroup group)
        {
            try
            {
                var result = this.groupService.InsertGroup(group);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Groups/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] UserGroup group)
        {
            try
            {
                var result = await this.groupService.UpdateGroupById(id, group).ConfigureAwait(false);
                return this.Ok(result);
            }
            catch (Exception)
            {
                throw;
            }

        }

        // DELETE: api/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this.groupService.DeleteGroup(id).ConfigureAwait(false);
                return this.Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
