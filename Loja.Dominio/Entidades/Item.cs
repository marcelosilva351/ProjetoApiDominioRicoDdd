using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Entidades
{
    public class Item : EntidadeBase
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public int PedidoId { get; set; }


        public Item(int produtoId, int quantidade)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
            Preco = Total();

        ;
        }

        public double Total()
        {
            return Preco * Quantidade;
        }
    }
}
