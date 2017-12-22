using MediatR;
using MediatrCrm.Domain.Models;
using MediatrCrm.Domain.Requests;
using MediatrCrm.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrCrm.Domain.Queries
{
    public class SingleContactRequest : GetByIdRequest<ContactDefaultViewModel>
    {        
    }
    public class SingleContactQuery : IRequestHandler<SingleContactRequest, ContactDefaultViewModel>
    {
        private readonly IDbContext dbcontext;

        public SingleContactQuery(IDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<ContactDefaultViewModel> Handle(SingleContactRequest request, CancellationToken cancellationToken)
        {
            var item = await this.dbcontext.GetById<Contact>(request.Id);
            return item.ToDefaultContactViewModel();                                        
        }
    }
}
