using MongoDB.Bson;
using MongoDB.Driver;
using ProjetoTeste.Domain.Entities.Base;
using ProjetoTeste.Infra.Context;
using ProjetoTeste.Infra.Repositories.Abstraction;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Infra.Repositories.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly IMongoDbContext Context;
        protected IMongoCollection<T> DbSet;

        public BaseRepository(IMongoDbContext context)
        {
            Context = context;
            DbSet = Context.GetCollection<T>(typeof(T).Name);
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            var objs = await DbSet.FindAsync(Builders<T>.Filter.Empty);
            return objs.ToList();
        }

        public virtual async Task<T> GetByIdAsync(ObjectId id)
        {
            var obj = await DbSet.FindAsync(Builders<T>.Filter.Eq("_id", id));
            return obj.FirstOrDefault();
        }

        public virtual async Task PostAsync(T obj)
        {
               Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        public virtual async Task PutAsync(T obj)
        {
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", obj.GetId()), obj)); //Para GetId() usar using ServiceStack;
        }

        public virtual async Task DeleteAsync(ObjectId id)
        {
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id)));
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
