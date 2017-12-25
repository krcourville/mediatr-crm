using System;
using MediatR;
using MediatrCrm.Domain.Contracts;

namespace MediatrCrm.Domain.Requests
{
    public class AddEntityRequest<TNewEntity, TResponse> : IRequest<TResponse> where TNewEntity : IEntity
    {
        public TNewEntity Entity
        {
            get;
            set;
        }
    }
}
