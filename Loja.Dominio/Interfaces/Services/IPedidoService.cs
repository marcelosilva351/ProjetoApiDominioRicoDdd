using Loja.Dominio.Dto_s.PedidosDTOS;
using Loja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Interfaces.Services
{
    public interface IPedidoService
    {
        Task AdicionarPedido(CreatePedidoDTO createPedidoDTO);
        Task ExcluirPedido(int idPedido);
        Task<List<ReadPedidoDTO>> ObterItensDoPedido(int idPedido);
        Task<List<ReadPedidoDTO>> ObterPedidosInclude();
        Task AdicionarItemAoPedido(int idProduto, int idPedido, int quantidadeDoProduto);
        Task PagarPedido(int idPedido, double valorPago);
        Task CancelarPedido(int idPedido);
         

    }
}
