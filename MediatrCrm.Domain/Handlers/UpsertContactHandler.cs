using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrCrm.Domain.Models;
using MediatrCrm.Domain.Requests;
using MediatrCrm.Domain.Responses;
using MediatrCrm.Domain.ViewModels;

namespace MediatrCrm.Domain.Handlers
{
    public class UpsertContactRequest : UpsertEntityRequest<Contact, UpsertContactResponse>
    {}

    public class UpsertContactResponse: UpsertEntityResponse<ContactDefaultViewModel>{}

    public class UpsertContactHandler : IRequestHandler<UpsertContactRequest, UpsertContactResponse>
    {
        private readonly IDbContext dbcontext;

        public UpsertContactHandler(IDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<UpsertContactResponse> Handle(UpsertContactRequest request, CancellationToken cancellationToken)
        {
            var entity = request.Entity;
            var id = request.Id ?? entity.UniqueId;
            var existing = await dbcontext.GetById<Contact>(id);
            var added = true;
            if(existing != null) {
                // TODO: do a true update of existing record
                added = false;
                await dbcontext.Delete(request.Entity);
            }
            var result = await dbcontext.Add(request.Entity);
            return new UpsertContactResponse
            {
                Added = added,
                Entity = result.ToDefaultContactViewModel()
            };

        }
    }
}
