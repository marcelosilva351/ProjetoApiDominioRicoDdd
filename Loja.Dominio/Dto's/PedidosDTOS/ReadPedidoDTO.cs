using Loja.Dominio.Entidades;
using Loja.Dominio.Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Dto_s.PedidosDTOS
{
    public class ReadPedidoDTO
    {
        public int Id { get; set; }
        public Client Cliente { get; set; }
        public DateTime DataPedido { get; set; }
        public string Numero { get; set; }
        public List<Item> Items { get; set; }
        public double TaxaDeEntrega { get; set; }
        public int DescsontoId { get; set; }
        public Desconto Desconto { get; set; }
        public double TotalPedido { get; set; }
        public EPedidoStatus Status { get; set; }
    }
}
