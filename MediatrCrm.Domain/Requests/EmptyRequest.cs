using System;
using MediatR;

namespace MediatrCrm.Domain.Requests
{
    public class EmptyRequest<T> : IRequest<T>{}
}
