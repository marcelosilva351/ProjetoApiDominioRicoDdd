using AutoMapper;
using Loja.Dominio.Dto_s.ClientesDTOS;
using Loja.Dominio.Entidades;
using Loja.Dominio.Interfaces.Repositorios;
using Loja.Dominio.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public async Task AdicionarCliente(CreateClienteDTO createClienteDTO)
        {
            var clienteAdd = _mapper.Map<Client>(createClienteDTO);
            await _clienteRepositorio.Adicionar(clienteAdd);

        }

        public async Task AtualizarCliente(int id, CreateClienteDTO createClienteDTO)
        {
            var clienteAtualizar = await _clienteRepositorio.ObterPorId(id);
         
            await _clienteRepositorio.Atualiar(clienteAtualizar);
        }

        public async Task ExcluirCliente(int idCliente)
        {
            var clienteExcluir = await _clienteRepositorio.ObterPorId(idCliente);
            await _clienteRepositorio.Excluir(clienteExcluir);
        }

        public async Task<Client> ObterClientePorId(int idCliente)
        {
            var clientePorId = await _clienteRepositorio.ObterPorId(idCliente);
            if(clientePorId == null)
            {
                return null;
            }
            return clientePorId;
        }

        public async Task<List<Client>> ObterClientes()
        {
            var clientes = await _clienteRepositorio.Obter();
            if(clientes == null)
            {
                return null;
            }
            return clientes;
        }
    }
}
