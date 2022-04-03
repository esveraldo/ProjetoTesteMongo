using AutoMapper;
using MongoDB.Bson;
using ProjetoTeste.Application.Dto;
using ProjetoTeste.Domain.Entities;
using ProjetoTeste.Infra.Repositories.Abstraction;
using ProjetoTeste.Infra.Services.Abstraction;
using ProjetoTeste.Infra.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Infra.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDto>> ObterTodosProdutos()
        {
            return _mapper.Map<IEnumerable<ProdutoDto>>(await _productRepository.GetAsync());
        }

        public async Task<ProdutoDto> ObterProdutoPorId(ObjectId id)
        {
            return _mapper.Map<ProdutoDto>(await _productRepository.GetByIdAsync(id));
        }
        
        public async Task<ProdutoRequestDto> SalvarProduto(ProdutoRequestDto produto)
        {
            var produtoParaCriar = _mapper.Map<Produto>(produto);

            if (produtoParaCriar.Nome == produto.Nome)
                return null;        

            produtoParaCriar.CreatedAt = DateTime.Now;
            produtoParaCriar.UpdateAt = DateTime.Now;   
            await _productRepository.PostAsync(produtoParaCriar);
            await _unitOfWork.CommitAsync();

            return produto;
        }

        public async Task<ProdutoDto> AlterarProduto(ProdutoDto produto)
        {
            var produtoParaAlterar = _mapper.Map<Produto>(produto);
            var produtoExistente = await _productRepository.GetByIdAsync(produtoParaAlterar.Id);
            produtoParaAlterar.UpdateAt = DateTime.UtcNow;
            produtoParaAlterar.CreatedAt = produtoExistente.CreatedAt;
            await _productRepository.PutAsync(produtoParaAlterar);
            await _unitOfWork.CommitAsync();

            return produto;
        }

        public async Task RemoverProdutoPorId(ObjectId id)
        {
            await _productRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }
    }
}
