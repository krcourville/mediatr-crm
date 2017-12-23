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
    public class GetSingleContactRequest : GetByIdRequest<ContactDefaultViewModel>
    {        
    }
    public class GetSingleContactHandler : IRequestHandler<GetSingleContactRequest, ContactDefaultViewModel>
    {
        private readonly IDbContext dbcontext;

        public GetSingleContactHandler(IDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<ContactDefaultViewModel> Handle(GetSingleContactRequest request, CancellationToken cancellationToken)
        {
            var item = await this.dbcontext.GetById<Contact>(request.Id);
            return item.ToDefaultContactViewModel();                                        
        }
    }
}
