using ProjetoTeste.Domain.Entities;
using ProjetoTeste.Infra.Context;
using ProjetoTeste.Infra.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Infra.Repositories.Implementation
{
    public class ProductRepository : BaseRepository<Produto>, IProductRepository
    {
        public ProductRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
