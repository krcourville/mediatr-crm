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
    public class UpsertMemberRequest : UpsertEntityRequest<Member, UpsertMemberResponse>
    {}

    public class UpsertMemberResponse: UpsertEntityResponse<MemberDefaultViewModel>{}

    public class UpsertMemberHandler : IRequestHandler<UpsertMemberRequest, UpsertMemberResponse>
    {
        private readonly IDbContext dbcontext;

        public UpsertMemberHandler(IDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<UpsertMemberResponse> Handle(UpsertMemberRequest request, CancellationToken cancellationToken)
        {
            var entity = request.Entity;
            var id = request.Id ?? entity.UniqueId;
            var existing = await dbcontext.GetById<Member>(id);
            var added = true;
            if(existing != null) {
                // TODO: do a true update of existing record
                added = false;
                await dbcontext.Delete(request.Entity);
            }
            var result = await dbcontext.Add(request.Entity);
            return new UpsertMemberResponse
            {
                Added = added,
                Entity = result.ToDefaultMemberViewModel()
            };

        }
    }
}
