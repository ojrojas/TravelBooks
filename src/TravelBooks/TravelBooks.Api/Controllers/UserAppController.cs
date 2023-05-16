using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserAppsController : ControllerBase
    {
        /// <summary>
        /// Async Identity Repository
        /// </summary>
        private readonly IIdentityService _identityService;

        /// <summary>
        /// Constructor User App Controller
        /// </summary>
        /// <param name="asyncIdentityRepository"></param>
        public UserAppsController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet]
        /// <summary>
        /// Get Users App
        /// </summary>
        /// <returns>List Users</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(IReadOnlyList<ApplicationUser>), StatusCodes.Status200OK)]
        public async Task<IReadOnlyList<ApplicationUser>> GetAllAsync()
        {
            return await this._identityService.GetAllAsync();
        }

        [HttpPost]
        /// <summary>
        /// Post User App
        /// </summary>
        /// <returns>User created</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApplicationUser), StatusCodes.Status200OK)]
        public async Task<ApplicationUser> CreateApplicationUser([FromBody] ApplicationUser user)
        {
            return await this._identityService.CreateApplicationUser(user);
        }

       
        [HttpPut]
        /// <summary>
        /// Put User App
        /// </summary>
        /// <returns>User created</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApplicationUser), StatusCodes.Status200OK)]
        public async Task<ApplicationUser> UpdateApplicationUser(ApplicationUser user)
        {
            return await this._identityService.UpdateApplicationUser(user);
        }

        [HttpDelete("{Id}")]
        /// <summary>
        /// Delete User App
        /// </summary>
        /// <returns>User created</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApplicationUser), StatusCodes.Status200OK)]
        public async Task<ApplicationUser> DeleteApplicationUser(Guid Id)
        {
            return await this._identityService.DeleteApplicationUser(Id);
        }

        [HttpGet]
        [Route("FindApplicationUser/{Id}")]
        /// <summary>
        /// Delete User App
        /// </summary>
        /// <returns>User created</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApplicationUser), StatusCodes.Status200OK)]
        public async Task<ApplicationUser> FindApplicationUser(Guid Id)
        {
            return await this._identityService.FindApplicationUser(Id);
        }
    }
}