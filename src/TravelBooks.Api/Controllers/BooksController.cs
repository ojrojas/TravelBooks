using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpGet]
        /// <summary>
        /// Get Books App
        /// </summary>
        /// <returns>List Users</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(IReadOnlyList<Book>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await this._bookService.GetAllBooks();
        }


        [HttpPost]
        /// <summary>
        /// Post Book App
        /// </summary>
        /// <returns>User created</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public async Task<Book> CreateAsync([FromBody] Book book)
        {
            return await this._bookService.Create(book);
        }


        [HttpPut]
        /// <summary>
        /// Put Book App
        /// </summary>
        /// <returns>User created</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public async Task<Book> UpdateAsync(Book book)
        {
            return await this._bookService.Edit(book);
        }

        [HttpDelete("{Id}")]
        /// <summary>
        /// Delete Book App
        /// </summary>
        /// <returns>User created</returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public async Task<Book> DeleteAsync(Guid Id)
        {
            return await this._bookService.Delete(Id);
        }
    }
}
