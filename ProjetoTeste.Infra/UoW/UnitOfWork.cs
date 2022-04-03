using ProjetoTeste.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoDbContext _mongoDbContext;

        public UnitOfWork(IMongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task<bool> CommitAsync()
        {
            var changes = await _mongoDbContext.SaveChangesAsync();
            return changes > 0;
        }

        public void Dispose()
        {
            _mongoDbContext.Dispose();
        }
    }
}
