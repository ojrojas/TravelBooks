using Core.Entities;
using Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.MockRepository
{
    public class BooksRepositoryMoq
    {
        public Mock<IBookService> _bookRepository;

        public BooksRepositoryMoq()
        {
            _bookRepository = new Mock<IBookService>();
            ConfiguracionEditorialRepositoryMoq();
        }

        private void ConfiguracionEditorialRepositoryMoq()
        {
            //Update
            _bookRepository.Setup((x) => x.Edit(
                It.IsAny<Book>())).ReturnsAsync(default(Book));
            //Create
            _bookRepository.Setup((x) => x.Create(
                It.IsAny<Book>())).ReturnsAsync(default(Book));
            //Delete
            _bookRepository.Setup((x) => x.Delete(
                It.IsAny<Guid>())).ReturnsAsync(default(Book));
            //Get
            _bookRepository.Setup((x) => x.GetAllBooks()).ReturnsAsync(default(List<Book>));
        }
    }
}
