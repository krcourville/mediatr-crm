using MediatR;
using MediatrCrm.Domain.Models;
using MediatrCrm.Domain.Requests;
using MediatrCrm.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrCrm.Domain.Handlers
{
    public class GetOneMemberRequest : GetByIdRequest<MemberDefaultViewModel>
    {        
    }
    public class GetOneMemberHandler : IRequestHandler<GetOneMemberRequest, MemberDefaultViewModel>
    {
        private readonly IDbContext dbcontext;

        public GetOneMemberHandler(IDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<MemberDefaultViewModel> Handle(GetOneMemberRequest request, CancellationToken cancellationToken)
        {
            var item = await this.dbcontext.GetById<Member>(request.Id);
            return item.ToDefaultMemberViewModel();                                        
        }
    }
}
