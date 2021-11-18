using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Entidades
{
    public class Desconto : EntidadeBase
    {
        public double Valor { get; set; }
        public DateTime DataExpiracao { get; set; }
        public Pedido Pedido { get; set; }

        public Desconto(double valor, DateTime dataExpiracao)
        {
            Valor = valor;
            DataExpiracao = dataExpiracao;
        }

        public bool DescontoValida()
        {
             if(DateTime.Compare(DateTime.Now, DataExpiracao) < 0)
            {
                return true;
            }
            return false;
        }
    }
}
