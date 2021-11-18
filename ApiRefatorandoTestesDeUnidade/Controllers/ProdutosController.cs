using Loja.Dominio.Dto_s.ProdutosDTOS;
using Loja.Dominio.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRefatorandoTestesDeUnidade.Controllers
{
    [ApiController]
    [Route("v1/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }


        [HttpPost]
        public async Task<ActionResult> CadastrarProduto([FromBody] CreateProdutoDTO createProdutoDTO)
        {
            try
            {
                await _produtoService.AdicionarProduto(createProdutoDTO);
                return Created("Produto criado", createProdutoDTO);

            }
            catch (Exception)
            {

                return StatusCode(500, "Banco de dados falhou ao adicionar produto");
            }
        }

        [HttpPut("DesativarProduto/{id}")]
        public async Task<ActionResult> DesataivarProdutoPeloId(int id)
        {
            try
            {
                await _produtoService.DesativarProduto(id);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "Erro ao atualizar produto");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObterProdutoPorId(int id)
        {
            var produtoPeloId = await _produtoService.ObterProdutoPorId(id);
            if (produtoPeloId == null)
            {
                return NotFound();
            }
            return Ok(produtoPeloId);
        }

        [HttpGet]
        public async Task<ActionResult> ObterProdutos()
        {
            var produtos = await _produtoService.ObterProdutos();
            if(produtos == null)
            {
                return NotFound();
            }
            return Ok(produtos);
        }

    }
}
