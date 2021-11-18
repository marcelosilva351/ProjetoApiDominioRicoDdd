using Loja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Dto_s.PedidosDTOS
{
    public class CreatePedidoDTO
    {
        [Required(ErrorMessage ="É necessario dizer a qual cliente perntence o pedido")]
        public int ClienteId { get; set; }
        public double TaxaDeEntrega { get; set; }

        public Desconto Desconto { get; set; }
    }
}
