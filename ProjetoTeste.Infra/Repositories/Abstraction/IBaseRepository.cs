using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Infra.Repositories.Abstraction
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        public Task<IEnumerable<T>> GetAsync();
        public Task<T> GetByIdAsync(ObjectId id);
        public Task PostAsync(T obj);
        public Task PutAsync(T obj);
        public Task DeleteAsync(ObjectId id);
    }
}
