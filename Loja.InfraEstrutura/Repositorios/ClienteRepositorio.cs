using Loja.Dominio.Entidades;
using Loja.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.InfraEstrutura.Repositorios
{
    public class ClienteRepositorio : Repositorio<Client>, IClienteRepositorio
    {
        public ClienteRepositorio(Contexto contexto) : base(contexto)
        {
        }

        public async Task<List<Pedido>> ObterPedidosDoCliente(int idCliente)
        {
            var pedidosCliente = await _contexto.Pedidos.Where(x => x.ClienteId == idCliente).ToListAsync();
            if(pedidosCliente == null)
            {
                return null;
            }
            return pedidosCliente;
        }
    }
}
