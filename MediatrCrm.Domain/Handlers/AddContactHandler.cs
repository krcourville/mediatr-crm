using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrCrm.Domain.Models;
using MediatrCrm.Domain.Requests;
using MediatrCrm.Domain.ViewModels;

namespace MediatrCrm.Domain.Handlers
{
    public class AddContactRequest : AddEntityRequest<Contact, ContactDefaultViewModel>{}

    public class AddContactHandler : IRequestHandler<AddContactRequest, ContactDefaultViewModel>
    {
        private readonly IDbContext dbcontext;

        public AddContactHandler(IDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<ContactDefaultViewModel> Handle(AddContactRequest request, CancellationToken cancellationToken)
        {
            var result = await dbcontext.Add(request.Entity);
            return result.ToDefaultContactViewModel();
        }
    }
}

   