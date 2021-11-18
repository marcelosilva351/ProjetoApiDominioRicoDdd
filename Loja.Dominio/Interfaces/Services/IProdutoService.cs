using Loja.Dominio.Dto_s.ProdutosDTOS;
using Loja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Interfaces.Services
{
    public interface IProdutoService
    {
        Task AdicionarProduto(CreateProdutoDTO createProdutoDTO);
        Task DesativarProduto(int produtoId);
        Task<Produto> ObterProdutoPorId(int produtoId);
        Task<List<Produto>> ObterProdutos();


    }
}
