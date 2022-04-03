using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using ProjetoTeste.Application.Dto;
using ProjetoTeste.Infra.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProductService _productService;
        //private readonly ILogger<ProdutosController> _logger;

        public ProdutosController(/*ILogger<ProdutosController> logger,*/ IProductService productService)
        {
            //_logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> Get()
        {
            try
            {
                var produtos = await _productService.ObterTodosProdutos();

                if (produtos == null)
                    return NotFound(new { message = "Não foram encontrados produtos cadastrados." });

                return Ok(produtos);
            }
            catch (Exception e)
            {

                return BadRequest(new { message = "Ocorreu um erro no sistema " + e.Message});
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDto>> GetById(string id)
        {
            try
            {
                var produto = await _productService.ObterProdutoPorId(ObjectId.Parse(id));

                if (produto == null)
                    return NotFound(new { message = "Produto não encontrado." });

                return Ok(produto);
            }
            catch (Exception e)
            {

                return BadRequest(new { message = "Ocorreu um erro no sistema " + e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoRequestDto>> Post([FromBody] ProdutoRequestDto produto)
        {
            try
            {
                var result = await _productService.SalvarProduto(produto);

                if (result == null)
                    return Ok("Esse produto já está cadastrado.");

                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(new { message = "Ocorreu um erro no sistema " + e.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProdutoDto>> Put([FromBody] ProdutoDto produto)
        {
            try
            {
                var result = await _productService.AlterarProduto(produto);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(new { message = "Ocorreu um erro no sistema " + e.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var produto = await _productService.ObterProdutoPorId(ObjectId.Parse(id));
                if (produto.Id != id)
                    return NotFound(new { message = "Produto não encontrado." });

                await _productService.RemoverProdutoPorId(ObjectId.Parse(id));
                return Ok("Produto removido com sucesso.");
            }
            catch (Exception e)
            {

                return BadRequest(new { message = "Ocorreu um erro no sistema " + e.Message });
            }
        }
    }
}
