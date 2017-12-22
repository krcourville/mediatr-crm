using System;
namespace MediatrCrm.Domain.ViewModels
{
    public class ContactDefaultViewModel
    {
        public ContactDefaultViewModel()
        {
        }

        public string Id { get; set; }

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
    }
}
