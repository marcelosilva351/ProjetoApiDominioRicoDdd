using Loja.Dominio.Dto_s.ProdutosDTOS;
using Loja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Interfaces.Repositorios
{
    public interface IProdutosRepositorio : IRepositorio<Produto>
    {
        Task<List<ReadProdutoDTO>> ObterProdutosAtivos();
    }
}
