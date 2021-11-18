using AutoMapper;
using Loja.Dominio.Dto_s.PedidosDTOS;
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
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepositorio pedidoRepositorio, IMapper mapper)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _mapper = mapper;
        }

        public async Task AdicionarItemAoPedido(int idProduto, int idPedido, int quantidadeDoProduto)
        {
            var pedido = await _pedidoRepositorio.ObterPorId(idPedido);
            if (pedido == null)
            {
                throw new NullReferenceException("Pedido não existe no banco de dados");
            }
            var produtoParaItem = await _pedidoRepositorio.ProdutoParaAdicionarItemNoPeiddo(idProduto);
            pedido.AdicionarItemAoPedido(idProduto, quantidadeDoProduto);
            await _pedidoRepositorio.Atualiar(pedido);
        }

        public async Task AdicionarPedido(CreatePedidoDTO createPedidoDTO)
        {
            var Desconto = new Desconto(createPedidoDTO.Desconto.Valor, createPedidoDTO.Desconto.DataExpiracao);
            await _pedidoRepositorio.AdicionarDesconto(Desconto);

            var pedidoAdd = new Pedido(createPedidoDTO.ClienteId, createPedidoDTO.TaxaDeEntrega, Desconto.Id);
            pedidoAdd.Total(createPedidoDTO.Desconto);
            await _pedidoRepositorio.Adicionar(pedidoAdd);
        }

        public async Task CancelarPedido(int idPedido)
        {
            var pedido = await _pedidoRepositorio.ObterPorId(idPedido);
            if(pedido == null)
            {
                throw new NullReferenceException("Pedido não existe no banco de dados");
            }
            pedido.Cancelar();
            await _pedidoRepositorio.Atualiar(pedido);
        }

        public async Task ExcluirPedido(int idPedido)
        {
            var pedidoExcluir = await _pedidoRepositorio.ObterPorId(idPedido);
            await _pedidoRepositorio.Excluir(pedidoExcluir);
        }

        public async Task<List<ReadPedidoDTO>> ObterItensDoPedido(int idPedido)
        {
            var pedidosDoCliente = await _pedidoRepositorio.ObterItensDoPedido(idPedido);
            if(pedidosDoCliente == null)
            {
                return null;
            }
            return pedidosDoCliente;
        }

        public async Task<List<ReadPedidoDTO>> ObterPedidosInclude()
        {
            var pedidosInclude = await _pedidoRepositorio.ObterPedidosInclude();
            if(pedidosInclude == null)
            {
                return null;
            }
            return pedidosInclude;
        }

        public async Task PagarPedido(int idPedido, double valorPago)
        {
            var pedido = await _pedidoRepositorio.ObterPorId(idPedido);
            if (pedido == null)
            {
                throw new NullReferenceException("Pedido não existe no banco de dados");
            }
            pedido.Pagar(valorPago);
            await _pedidoRepositorio.Atualiar(pedido);

        }
    }
}
