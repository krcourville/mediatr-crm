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
    public class GetAllContactsRequest : EmptyRequest<IEnumerable<ContactDefaultViewModel>> { }

    public class GetAllContactsHandler : IRequestHandler<GetAllContactsRequest, IEnumerable<ContactDefaultViewModel>>
    {
        private readonly IDbContext dbcontext;

        public GetAllContactsHandler(IDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<IEnumerable<ContactDefaultViewModel>> Handle(GetAllContactsRequest request, CancellationToken cancellationToken)
        {
            var items = await dbcontext.GetAll<Contact>();
            return items.ToDefaultContactViewModel();
        }
    }
}
