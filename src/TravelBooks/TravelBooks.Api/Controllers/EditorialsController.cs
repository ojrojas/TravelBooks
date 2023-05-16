using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialsController : ControllerBase
    {
        private readonly IEditorialService _editorialService;

        public EditorialsController(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }

        [HttpGet]
        /// <summary>
        /// Get Editorial App
        /// </summary>
        /// <returns>List Users</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(IReadOnlyList<Editorial>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<Editorial>> GetAllAsync()
        {
            return await this._editorialService.GetAllEditorials();
        }


        [HttpPost]
        /// <summary>
        /// Post Editorial App
        /// </summary>
        /// <returns>User created</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(Editorial), StatusCodes.Status200OK)]
        public async Task<Editorial> CreateAsync([FromBody] Editorial editorial)
        {
            return await this._editorialService.Create(editorial);
        }


        [HttpPut]
        /// <summary>
        /// Put Editorial App
        /// </summary>
        /// <returns>User created</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(Editorial), StatusCodes.Status200OK)]
        public async Task<Editorial> UpdateAsync(Editorial editorial)
        {
            return await this._editorialService.Edit(editorial);
        }

        [HttpDelete("{Id}")]
        /// <summary>
        /// Delete Editorial App
        /// </summary>
        /// <returns>User created</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(Editorial), StatusCodes.Status200OK)]
        public async Task<Editorial> DeleteAsync(Guid Id)
        {
            return await this._editorialService.Delete(Id);
        }
    }
}
