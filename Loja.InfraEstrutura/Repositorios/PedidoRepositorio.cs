using Loja.Dominio.Dto_s.PedidosDTOS;
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
    public class PedidoRepositorio : Repositorio<Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(Contexto contexto) : base(contexto)
        {
        }

        public async Task<List<ReadPedidoDTO>> ObterItensDoPedido(int idPedido)
        {
            var itensDoPedido = await _contexto.Pedidos.Include(i => i.Items).Where(p => p.Id == idPedido).Select
              (x => new ReadPedidoDTO
              {
                  Items = x.Items.ToList()
              }).ToListAsync();
            if(itensDoPedido == null)
            {
                return null;
            }
            return itensDoPedido;
        }

        public async Task<Produto> ProdutoParaAdicionarItemNoPeiddo(int id)
        {
            var produto = await _contexto.Produtos.FindAsync(id);
            return produto;
        }


        public async Task<List<ReadPedidoDTO>> ObterPedidosInclude()
        {
            var itensDoPedido = await _contexto.Pedidos.Include(i => i.Items).ThenInclude(p => p.Produto).Include(X => X.Cliente).Include(X => X.Desconto).Select
                (x => new ReadPedidoDTO {
                    Status = x.Status,
                    Cliente = x.Cliente,
                    Desconto = x.Desconto,
                    Items = x.Items,
             
                    DataPedido = x.DataPedido,
                    Id = x.Id,
                    TotalPedido = x.TotalPedido,
                    TaxaDeEntrega = x.TaxaDeEntrega,
                    Numero = x.Numero
                }).ToListAsync();
             if(itensDoPedido == null)
            {
                return null;
            }
            return itensDoPedido;
        }
        public async Task AdicionarDesconto(Desconto desconto)
        {
            _contexto.Descontos.Add(desconto);
            await _contexto.SaveChangesAsync();
        }
    }
}
