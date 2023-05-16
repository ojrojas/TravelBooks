using Core.Entities;
using Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;

namespace Test.MockRepository
{
    public class AuthorsRepositoryMoq
    {
        public Mock<IAuthorService> _authorRepository;

        public AuthorsRepositoryMoq()
        {
            _authorRepository = new Mock<IAuthorService>();
            ConfiguracionAuthorRepositoryMoq();
        }

        private void ConfiguracionAuthorRepositoryMoq()
        {
            //Update
            _authorRepository.Setup((x) => x.Edit(
                It.IsAny<Author>())).ReturnsAsync(default(Author));
            //Create
            _authorRepository.Setup((x) => x.Create(
                It.IsAny<Author>())).ReturnsAsync(default(Author));
            //Delete
            _authorRepository.Setup((x) => x.Delete(
                It.IsAny<Guid>())).ReturnsAsync(default(Author));
            //Get
            _authorRepository.Setup((x) => x.GetAllAuthors()).ReturnsAsync(default(List<Author>));
        }
    }
}
