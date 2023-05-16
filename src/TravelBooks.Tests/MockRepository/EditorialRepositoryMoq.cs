using Core.Entities;
using Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;

namespace Test.MockRepository
{
    public class EditorialRepositoryMoq
    {
        public Mock<IEditorialService> __editorialRepository;

        public EditorialRepositoryMoq()
        {
            __editorialRepository = new Mock<IEditorialService>();
            ConfiguracionEditorialRepositoryMoq();
        }

        private void ConfiguracionEditorialRepositoryMoq()
        {
            //Update
            __editorialRepository.Setup((x) => x.Edit(
                It.IsAny<Editorial>())).ReturnsAsync(default(Editorial));
            //Create
            __editorialRepository.Setup((x) => x.Create(
                It.IsAny<Editorial>())).ReturnsAsync(default(Editorial));
            //Delete
            __editorialRepository.Setup((x) => x.Delete(
                It.IsAny<Guid>())).ReturnsAsync(default(Editorial));
            //Get
            __editorialRepository.Setup((x) => x.GetAllEditorials()).ReturnsAsync(default(List<Editorial>));
        }
    }
}
