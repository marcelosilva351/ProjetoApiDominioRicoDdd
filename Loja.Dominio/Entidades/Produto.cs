using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Entidades
{
    public class Produto : EntidadeBase
    {
        public string Titulo { get; private set; }
        public double Preco { get; private set; }
        public bool Ativo { get; private set; }
        public List<Item> Items { get; set; }
        public Produto(string titulo, double preco, bool ativo)
        {
            Titulo = titulo;
            Preco = preco;
            Ativo = ativo;
        }

        public void desativarProduto()
        {
            this.Ativo = false;
        }
    }
}
