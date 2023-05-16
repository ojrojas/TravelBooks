using Core.Entities;
using Core.Interfaces;
using Core.Services.Editorials;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.MockRepository;
using Xunit;

namespace Test.MockService
{
    public class EditorialServiceMoq
    {
        private static IEditorialService _editorialService;
        private readonly IAsyncRepository<Editorial> _asyncRepository;
        public EditorialServiceMoq()
        {
            Mock<IEditorialService> _authorRepository = new EditorialRepositoryMoq().__editorialRepository;
            _editorialService = new EditorialService(_asyncRepository);
        }

        [Fact]
        public async Task TestMethoEditAsync()
        {
            var result = await _editorialService.Edit(new Editorial
            {
                Id = Guid.NewGuid(),
                ModifiedBy = Guid.NewGuid(),
                ModifiedOn = DateTime.Now,
                Sede = "asdfasdf",
                Name = "dafdsf",
                State = true
            });

            result.Should().Be(default(Editorial));
        }


        [Fact]
        public async Task TestMethoCreateAsync()
        {
            var result = await _editorialService.Create(new Editorial
            {
                Id = Guid.NewGuid(),
                ModifiedBy = Guid.NewGuid(),
                ModifiedOn = DateTime.Now,
                Sede = "asdfasdf",
                Name = "dafdsf",
                State = true
            });

            result.Should().Be(default(Editorial));
        }

        [Fact]
        public async Task TestMethoDeleteAsync()
        {
            var result = await _editorialService.Delete(Guid.NewGuid());

            result.Should().Be(default(Editorial));
        }

    }
}
