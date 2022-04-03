using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Application.Dto
{
    public class ProdutoRequestDto
    {
        public decimal Price { get; set; }
        public string Nome { get; set; }
        public string Description { get; set; }
    }
}
