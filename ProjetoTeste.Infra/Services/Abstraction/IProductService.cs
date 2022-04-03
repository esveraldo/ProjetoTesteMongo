using MongoDB.Bson;
using ProjetoTeste.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Infra.Services.Abstraction
{
    public interface IProductService
    {
        public Task<IEnumerable<ProdutoDto>> ObterTodosProdutos();
        public Task<ProdutoDto> ObterProdutoPorId(ObjectId id);
        public Task<ProdutoRequestDto> SalvarProduto(ProdutoRequestDto produto);
        public Task<ProdutoDto> AlterarProduto(ProdutoDto produto);
        public Task RemoverProdutoPorId(ObjectId id);
    }
}
