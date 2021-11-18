using AutoMapper;
using Loja.Dominio.Dto_s.ProdutosDTOS;
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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutosRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutosRepositorio produtoRepositorio, IMapper mapper)
        {
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
        }

        public async Task AdicionarProduto(CreateProdutoDTO createProdutoDTO)
        {
            var produtoAdd = new Produto(createProdutoDTO.Titulo, createProdutoDTO.Preco, true);
            await _produtoRepositorio.Adicionar(produtoAdd);
        }

        public async Task DesativarProduto(int produtoId)
        {
            var produto = await _produtoRepositorio.ObterPorId(produtoId);
            if(produto.Ativo == false)
            {
                throw new InvalidOperationException("Produto já está desativado");
            }
            produto.desativarProduto();
            await _produtoRepositorio.Adicionar(produto);

        }

        public async Task<Produto> ObterProdutoPorId(int produtoId)
        {
            var produto = await _produtoRepositorio.ObterPorId(produtoId);
            if (produto == null)
            {
                return null;
            }
            return produto;
        }

        public async Task<List<Produto>> ObterProdutos()
        {
            var produtos = await _produtoRepositorio.Obter();
            if(produtos == null)
            {
                return null;
            }
            return produtos;
        }
    }

}
