using ProjetoTeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Infra.Repositories.Abstraction
{
    public interface IProductRepository : IBaseRepository<Produto>
    {
    }
}
