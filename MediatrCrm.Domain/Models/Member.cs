using MediatrCrm.Domain.Contracts;
using System;
namespace MediatrCrm.Domain.Models
{
    /// <summary>
    /// Represents a Member pulled directly from the data store
    /// </summary>
    public class Member : IEntity
    {
        public Member()
        {
        }

        public string UniqueId { get; set; }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Warning: This value should not be exposed casually!
        /// </summary>
        /// <value>The member secret1.</value>
        public string MemberSecret1
        {
            get;
            set;
        }
    }
}
