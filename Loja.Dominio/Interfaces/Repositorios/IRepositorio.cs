using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Interfaces.Repositorios
{
    public interface IRepositorio<T> where T :class
    {
        Task Adicionar(T entidadeAdd);
        Task Atualiar(T entidadeUpdate);
        Task Excluir(T entidadeRemove);
        Task<List<T>> Obter();
        Task<T> ObterPorId(int id);
     

    }
}
