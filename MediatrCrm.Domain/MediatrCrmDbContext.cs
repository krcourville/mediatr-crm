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
        Task<T> Add<T>(T entity) where T : IEntity;
        Task<bool> Delete<T>(T entity) where T : IEntity;
    }

    /// <summary>
    /// WARNING: This is strictly for illustration purposes and is not a good 
    /// pattern to follow!
    /// 
    /// For example: the static lists are not thread safe
    /// </summary>
    public class MediatrCrmDbContext : IDbContext
    {
        private static List<Contact> mockContacts = new List<Contact>{
            new Contact {
                UniqueId = "3d206612de8e",
                FirstName = "Joe",
                LastName = "Schmoe",
                ContactSecret1 = "secret1"
            },
            new Contact {
                UniqueId = "474af0de6a74",
                FirstName = "Sally",
                LastName = "Smith",
                ContactSecret1 = "sally's secret"
            }
        };

        public Task<T> Add<T>(T entity) where T : IEntity
        {
			entity.UniqueId = entity.UniqueId ?? NewId();
            var set = GetDbSet<T>();
            set.Add(entity);
            return Task.FromResult(entity);

        }

        private string NewId()
        {
            var guid = Guid.NewGuid().ToString();
            return guid.Split('-').Last();
        }

        public Task<IEnumerable<T>> GetAll<T>() where T : IEntity
        {
            return Task.FromResult( GetDbSet<T>() as IEnumerable<T>);
        }

        public Task<T> GetById<T>(string id) where T : IEntity
        {
            var set = GetDbSet<T>();
            var item = set.SingleOrDefault(s => s.UniqueId == id);
            return Task.FromResult(item);
        }

        private IList<T> GetDbSet<T>() where T : IEntity
        {
            if (typeof(T) == typeof(Contact))
            {
                return mockContacts as IList<T>;
            }
            else
            {
                throw new InvalidOperationException();
            }            
        }

        public Task<bool> Delete<T>(T entity) where T : IEntity
        {
            var set = GetDbSet<T>();
            set.Remove(entity);
            return Task.FromResult(true);
        }
    }
}
