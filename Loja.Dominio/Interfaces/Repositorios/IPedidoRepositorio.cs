using Loja.Dominio.Dto_s.PedidosDTOS;
using Loja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Interfaces.Repositorios
{
    public interface IPedidoRepositorio : IRepositorio<Pedido>
    {
        Task<List<ReadPedidoDTO>> ObterPedidosInclude();
        Task<List<ReadPedidoDTO>> ObterItensDoPedido(int idPedido);
        public Task AdicionarDesconto(Desconto desconto);
        public  Task<Produto> ProdutoParaAdicionarItemNoPeiddo(int id);


    }
}
