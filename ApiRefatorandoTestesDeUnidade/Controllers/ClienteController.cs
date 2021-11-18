using Loja.Dominio.Dto_s.ClientesDTOS;
using Loja.Dominio.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRefatorandoTestesDeUnidade.Controllers
{
    [ApiController]
    [Route("v1/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpPost]
        public async Task<ActionResult> CadastrarCliente([FromBody] CreateClienteDTO clienteDto)
        {
            try
            {
                await _clienteService.AdicionarCliente(clienteDto);
                return Created("Cliente criado", clienteDto);
            }
            catch (Exception e)
            {

                return StatusCode(500, "Banco de dados falhou ao adicionar o cliente");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirCliente(int id)
        {
            try
            {
                await _clienteService.ExcluirCliente(id);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "Banco de dados falhou ao deletar cliente");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObterClientePorId(int id)
        {
            var clientePorId = await _clienteService.ObterClientePorId(id);
            if(clientePorId == null)
            {
                return NotFound("Cliente não encontrado");
            }
            return Ok(clientePorId);
        }

        [HttpGet]
        public async Task<ActionResult> ObterClientes()
        {
            var clientes = await _clienteService.ObterClientes();
            if(clientes == null)
            {
                return NotFound("Lista de clientes vazia");
            }
            return Ok(clientes);
        }



    }
}
