using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrCrm.Domain.Requests;
using MediatrCrm.Domain.ViewModels;
using MediatrCrm.Domain.Models;
using System.Linq;
using System.Linq.Expressions;

namespace MediatrCrm.Domain.Handlers
{
    public class GetAllMembersRequest : EmptyRequest<IEnumerable<MemberDefaultViewModel>> { }

    public class GetAllMembersHandler : IRequestHandler<GetAllMembersRequest, IEnumerable<MemberDefaultViewModel>>
    {
        private readonly IDbContext dbcontext;

        public GetAllMembersHandler(IDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<IEnumerable<MemberDefaultViewModel>> Handle(GetAllMembersRequest request, CancellationToken cancellationToken)
        {
            var items = await dbcontext.GetAll<Member>();
            return items.ToDefaultMemberViewModel();
        }
    }
}
