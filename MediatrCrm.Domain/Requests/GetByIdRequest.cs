using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatrCrm.Domain.Requests
{
    public class GetByIdRequest<T> : IRequest<T> {
        public string Id { get; set; }
    }
}
