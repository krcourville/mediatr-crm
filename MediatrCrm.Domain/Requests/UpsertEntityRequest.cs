using System;
using MediatR;
using MediatrCrm.Domain.Contracts;

namespace MediatrCrm.Domain.Requests
{
    public class UpsertEntityRequest<TEntity, TResponse> : IRequest<TResponse> where TEntity : IEntity
    {
        public string Id
        {
            get;
            set;
        }
        public TEntity Entity
        {
            get;
            set;
        }
    }
}
