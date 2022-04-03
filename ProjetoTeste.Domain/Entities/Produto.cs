using ProjetoTeste.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public decimal Price { get; set; }
        public string Nome { get; set; }
        public string Description { get; set; }
    }
}
