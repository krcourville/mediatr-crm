using System;
using System.Threading;
using MediatrCrm.Domain;
using MediatrCrm.Domain.Handlers;
using MediatrCrm.Domain.Models;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace MediatrCrm.UnitTests
{
    public class UpsertContactHandlerTests
    {
        [Fact]
        public async Task when_inserted_added_equals_true() {
            // prepare
			var sut = GetSut();
            var request = new UpsertContactRequest
            {
                Id = Guid.NewGuid().ToString(),
                Entity = new Contact
                {
                    FirstName = "John",
                    LastName = "Smith"
                }
            };
            // execute
            var response = await sut.Handle(request, new CancellationToken());
            // verify
            response.Added.Should().BeTrue();
        }

        [Fact]
        public async Task when_updated_added_equals_false() {
            // prepare
            var items = await GetDbContext().GetAll<Contact>();
            var firstItem = items.FirstOrDefault();
            var sut = GetSut();
            var request = new UpsertContactRequest
            {
                Id = firstItem.UniqueId,
                Entity = new Contact
                {
                    FirstName = "John",
                    LastName = "Smith"
                }
            };
            // execute
            var response = await sut.Handle(request, new CancellationToken());
            // verify
            response.Added.Should().BeFalse();
        }

        IDbContext GetDbContext() {
            return new MediatrCrmDbContext();
        }

        UpsertContactHandler GetSut()
        {
            return new UpsertContactHandler(GetDbContext());
        }
    }
}
