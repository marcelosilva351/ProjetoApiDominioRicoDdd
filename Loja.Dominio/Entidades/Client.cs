using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Entidades
{
    public class Client : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public List<Pedido> Pedidos { get; set; }

        public Client(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
