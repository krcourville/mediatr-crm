using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MediatrCrm.Domain.Queries;
using MediatrCrm.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MediatrCrm.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        readonly IMediator mediator;

        public ContactsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // api/contacts
        [HttpGet]
        public async Task<IEnumerable<ContactDefaultViewModel>> Get(AllContactsRequest request) {
            return await mediator.Send(request);
        }

        // api/contacts/{id}
        [HttpGet("{id}")]
        public async Task<ContactDefaultViewModel> Get(SingleContactRequest request)
        {
            return await mediator.Send(request);
        }
    }
}
