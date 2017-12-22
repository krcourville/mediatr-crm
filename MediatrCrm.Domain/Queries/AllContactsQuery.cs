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

namespace MediatrCrm.Domain.Queries
{
    public class AllContactsRequest : EmptyRequest<IEnumerable<ContactDefaultViewModel>> { }

    public class AllContactsQuery : IRequestHandler<AllContactsRequest, IEnumerable<ContactDefaultViewModel>>
    {
        private readonly IDbContext dbcontext;

        public AllContactsQuery(IDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<IEnumerable<ContactDefaultViewModel>> Handle(AllContactsRequest request, CancellationToken cancellationToken)
        {
            var items = await dbcontext.GetAll<Contact>();
            return items.ToDefaultContactViewModel();
        }
    }
}
