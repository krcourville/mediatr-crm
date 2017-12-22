using System;
using System.Collections.Generic;
using System.Text;

namespace MediatrCrm.Domain.Contacts
{
    public interface IEntity
    {
        string UniqueId { get; set; }
    }
}
