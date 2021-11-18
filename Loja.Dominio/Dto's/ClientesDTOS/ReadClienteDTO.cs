using Loja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Dto_s.ClientesDTOS
{
    public class ReadClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public List<Pedido> Pedidos { get; set; }
    }
}
