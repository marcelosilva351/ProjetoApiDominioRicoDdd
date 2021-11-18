using Loja.Dominio.Dto_s.ProdutosDTOS;
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
    public class ProdutoRepositorio : Repositorio<Produto>, IProdutosRepositorio
    {
        public ProdutoRepositorio(Contexto contexto) : base(contexto)
        {
        }

        public async Task<List<ReadProdutoDTO>> ObterProdutosAtivos()
        {
            var produtoAtivos = await _contexto.Produtos.Where(p => p.Ativo == true).Select(x => new ReadProdutoDTO
            {
                Id = x.Id,
                Preco = x.Preco,
                Titulo = x.Titulo
            }).ToListAsync();
            if(produtoAtivos == null)
            {
                return null;
            }
            return produtoAtivos;
        }
    }
}
