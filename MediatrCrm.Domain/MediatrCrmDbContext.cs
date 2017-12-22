using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatrCrm.Domain.Models;
using System.Linq;
using System.Linq.Expressions;
using MediatrCrm.Domain.Contacts;

namespace MediatrCrm.Domain
{
    public interface IDbContext
    {
        Task<IEnumerable<T>> GetAll<T>() where T : IEntity;
        Task<T> GetById<T>(string id) where T : IEntity;
    }

    public class MediatrCrmDbContext : IDbContext
    {
        private List<Contact> mockContacts = new List<Contact>{
            new Contact {
                UniqueId = "0f4e859fdd2",
                FirstName = "Joe",
                LastName = "Schmoe",
                ContactSecret1 = "secret1"
            },
            new Contact {
                UniqueId = "252f20ff6c0",
                FirstName = "Sally",
                LastName = "Smith",
                ContactSecret1 = "sally's secret"
            }
        };

        public Task<IEnumerable<T>> GetAll<T>() where T : IEntity
        {
            return Task.FromResult( GetDbSet<T>());
        }

        public Task<T> GetById<T>(string id) where T : IEntity
        {
            var set = GetDbSet<T>();
            var item = set.SingleOrDefault(s => s.UniqueId == id);
            return Task.FromResult(item);
        }

        private IEnumerable<T> GetDbSet<T>() where T : IEntity
        {
            if (typeof(T) == typeof(Contact))
            {
                return mockContacts as IEnumerable<T>;
            }
            else
            {
                throw new InvalidOperationException();
            }            
        }
    }
}
