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
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        /// <summary>
        /// Get Author App
        /// </summary>
        /// <returns>List Users</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(IReadOnlyList<Author>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await this._authorService.GetAllAuthors();
        }


        [HttpPost]
        /// <summary>
        /// Post Editorial App
        /// </summary>
        /// <returns>User created</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
        public async Task<Author> CreateAsync([FromBody] Author author)
        {
            return await this._authorService.Create(author);
        }


        [HttpPut]
        /// <summary>
        /// Put Author  App
        /// </summary>
        /// <returns>User created</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(Editorial), StatusCodes.Status200OK)]
        public async Task<Author> UpdateAsync(Author author)
        {
            return await this._authorService.Edit(author);
        }

        [HttpDelete("{Id}")]
        /// <summary>
        /// Delete author App
        /// </summary>
        /// <returns>User created</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(Editorial), StatusCodes.Status200OK)]
        public async Task<Author> DeleteAsync(Guid Id)
        {
            return await this._authorService.Delete(Id);
        }
    }
}
