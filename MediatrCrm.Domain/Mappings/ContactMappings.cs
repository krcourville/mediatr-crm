using MediatrCrm.Domain.Models;
using MediatrCrm.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace MediatrCrm.Domain
{
    public static class ContactMappings
    {
        /// <summary>
        /// Convert Contact to ContactDefaultViewModel
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public static ContactDefaultViewModel ToDefaultContactViewModel(this Contact contact)
        {
            if(contact == null)
            {
                return null;
            }

            return new ContactDefaultViewModel
            {
                Id = contact.UniqueId,
                FirstName = contact.FirstName,
                LastName = contact.LastName
            };
        }

        /// <summary>
        /// Convert IEnumerable<Contact> to IEnumerable<ContactDefaultViewModel>
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        public static IEnumerable<ContactDefaultViewModel> ToDefaultContactViewModel(this IEnumerable<Contact> contacts)
        {
            return contacts.Select(ToDefaultContactViewModel);
        }
    }
}
