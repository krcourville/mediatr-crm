using MediatrCrm.Domain.Contacts;
using System;
namespace MediatrCrm.Domain.Models
{
    /// <summary>
    /// Represents a Contact pulled directly from the data store
    /// </summary>
    public class Contact : IEntity
    {
        public Contact()
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
        /// <value>The contact secret1.</value>
        public string ContactSecret1
        {
            get;
            set;
        }
    }
}
