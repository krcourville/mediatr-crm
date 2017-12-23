using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MediatrCrm.Domain.Handlers;
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

        // GET api/contacts
        [HttpGet]
        public async Task<IEnumerable<ContactDefaultViewModel>> Get(GetAllContactsRequest request) {
            return await mediator.Send(request);
        }

        // GET api/contacts/{id}
        [HttpGet("{id}")]
        public async Task<ContactDefaultViewModel> Get(GetSingleContactRequest request)
        {
            return await mediator.Send(request);
        }

        // POST api/contacts/{id}
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddContactRequest request) {
            var result = await mediator.Send(request);
            return CreatedAtAction("Get", new { id = result.Id }, result);
        }
    }
}
