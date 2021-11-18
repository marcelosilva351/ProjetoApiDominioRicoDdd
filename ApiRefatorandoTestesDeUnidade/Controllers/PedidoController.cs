using Loja.Dominio.Dto_s.PedidosDTOS;
using Loja.Dominio.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRefatorandoTestesDeUnidade.Controllers
{

    [ApiController]
    [Route("v1/pedidos")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPut("AddItemAoPedido/{idProduto}/{idPedido}/{qtd}")]
        public async Task<ActionResult> AddItemAoPedido(int idProduto,int idPedido,int qtd)
        {
            try
            {
                await _pedidoService.AdicionarItemAoPedido(idProduto, idPedido, qtd);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> adicionarPedido(CreatePedidoDTO createPedidoDTO)
        {
            try
            {
                await _pedidoService.AdicionarPedido(createPedidoDTO);
                return Created("Pedido adicionado", createPedidoDTO);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("ObterPedidosInclude")]
        public async Task<ActionResult<List<ReadPedidoDTO>>> ObterPedidos()
        {
            var pedidos = await _pedidoService.ObterPedidosInclude();
            if(pedidos == null)
            {
                return NotFound();
            }
            return Ok(pedidos);
        }

        [HttpPut("CancelarPedido/{idPedido}")]
        public async Task<ActionResult> CancelarPedido(int idPedido)
        {
            try
            {
                await _pedidoService.CancelarPedido(idPedido);
                return NoContent();
            }
            catch (Exception)
            {

               return StatusCode(500, "Ocorreu um erro ao cancelar o pedido");
            }
        }

        [HttpDelete("ExcluirPedido/{idPedido}")]
        public async Task<ActionResult> ExcluirPedido(int idPedido)
        {
            try
            {
                await _pedidoService.ExcluirPedido(idPedido);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao excluir o pedido");
            }
        }

    }
}
