using Loja.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.InfraEstrutura.Repositorios
{
    public abstract class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected readonly Contexto _contexto;

        protected Repositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(T entidadeAdd)
        {
            _contexto.Set<T>().Add(entidadeAdd);
            await _contexto.SaveChangesAsync();
        }

        public async Task Atualiar(T entidadeUpdate)
        {
            _contexto.Set<T>().Update(entidadeUpdate);
            await _contexto.SaveChangesAsync();
        }

        public async Task Excluir(T entidadeRemove)
        {
            _contexto.Set<T>().Remove(entidadeRemove);
            await _contexto.SaveChangesAsync();
         }

        public async Task<List<T>> Obter()
        {
            var entidades = await _contexto.Set<T>().ToListAsync();
            if(entidades == null)
            {
                return null;
            }
            return entidades;
        }

        public async Task<T> ObterPorId(int id)
        {
            var entidadePorId = await _contexto.Set<T>().FindAsync(id);
            if (entidadePorId == null)
            {
                return null;
            }
            return entidadePorId;
        }
    }
}
