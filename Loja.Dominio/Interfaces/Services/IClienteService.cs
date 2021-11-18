using Loja.Dominio.Dto_s.ClientesDTOS;
using Loja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Interfaces.Services
{
    public interface IClienteService
    {
        Task AdicionarCliente(CreateClienteDTO createClienteDTO);
        Task AtualizarCliente(int id,CreateClienteDTO createClienteDTO);
        Task ExcluirCliente(int idCliente);
        Task<List<Client>> ObterClientes();
        Task<Client> ObterClientePorId(int idCliente);
    }
}
