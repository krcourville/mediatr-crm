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
    public class MembersController : Controller
    {
        readonly IMediator mediator;

        public MembersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET api/members
        [HttpGet]
        public async Task<IEnumerable<MemberDefaultViewModel>> Get(GetAllMembersRequest request) {
            return await mediator.Send(request);
        }

        // GET api/members/{id}
        [HttpGet("{id}")]
        public async Task<MemberDefaultViewModel> Get(GetOneMemberRequest request)
        {
            return await mediator.Send(request);
        }

        // POST api/members
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddMemberRequest request) {
            var result = await mediator.Send(request);
            return CreatedAtAction("Get", new { id = result.Id }, result);
        }

        // PUT api/members/{id}
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpsertMemberRequest request) {
            var result = await mediator.Send(request);
            var entity = result.Entity;
            if(result.Added){
                return CreatedAtAction("Get", new { id = entity.Id }, entity);
            }
            return Ok();
        }
    }
}
