using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrCrm.Domain.Models;
using MediatrCrm.Domain.Requests;
using MediatrCrm.Domain.ViewModels;

namespace MediatrCrm.Domain.Handlers
{
    public class AddMemberRequest : AddEntityRequest<Member, MemberDefaultViewModel>{}

    public class AddMemberHandler : IRequestHandler<AddMemberRequest, MemberDefaultViewModel>
    {
        private readonly IDbContext dbcontext;

        public AddMemberHandler(IDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<MemberDefaultViewModel> Handle(AddMemberRequest request, CancellationToken cancellationToken)
        {
            var result = await dbcontext.Add(request.Entity);
            return result.ToDefaultMemberViewModel();
        }
    }
}

   