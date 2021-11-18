using Loja.Dominio.Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Entidades
{
    public class Pedido : EntidadeBase
    {

        public int ClienteId { get; set; }
        public Client Cliente { get; set; }
        public DateTime DataPedido { get; set; }
        public string Numero { get; set; }
        public List<Item> Items { get; set; } 
        public double TaxaDeEntrega { get; set; }
        public int DescontoId { get; set; }
        public Desconto Desconto { get; set; }
        public double TotalPedido { get; set; }
        public EPedidoStatus Status { get; set; }

        public Pedido(int clienteId,double taxaDeEntrega, int descontoId)
        {
            ClienteId = clienteId;
            DataPedido = DateTime.Now;
            Numero = new Guid().ToString().Substring(0,8);
            Items = new List<Item>();
            TaxaDeEntrega = taxaDeEntrega;
            DescontoId  = descontoId;
            Status = EPedidoStatus.AguardandoPagamento;
            TotalPedido = 0;

        }

        public void AdicionarItemAoPedido(int idproduto, int quantidade)
        {
            Item itemPedido = new Item(idproduto, quantidade);
            Items.Add(itemPedido);
        }
        public void Total(Desconto desconto)
        {
            foreach (var item in Items)
            {
                TotalPedido += item.Total();
            }
            TotalPedido += TaxaDeEntrega;
            if(desconto.Valor > 0)
            {
                TotalPedido -= desconto.Valor;
            }
        }
        public bool Pagar(double valorPago)
        {
            if(valorPago >= TotalPedido)
            {
                Status = EPedidoStatus.AguardandoEntrega;
                return true;
            }
            return false;
        }

        public void Cancelar()
        {
            Status = EPedidoStatus.Cancelado;
        }
    }
}
