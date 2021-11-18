using Loja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Interfaces.Repositorios
{
    public interface IClienteRepositorio : IRepositorio<Client>
    {
        Task<List<Pedido>> ObterPedidosDoCliente(int idCliente);

    }
}
