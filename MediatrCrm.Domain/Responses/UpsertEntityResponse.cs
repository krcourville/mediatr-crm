using System;
namespace MediatrCrm.Domain.Responses
{
    public class UpsertEntityResponse<TEntity>
    {
        public TEntity Entity
        {
            get;
            set;
        }

        public bool Added
        {
            get;
            set;
        }
    }
}
