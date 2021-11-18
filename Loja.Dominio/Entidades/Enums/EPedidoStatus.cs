using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Entidades.Enums
{
    public enum EPedidoStatus
    {
        AguardandoPagamento = 1,
        AguardandoEntrega = 2,
        Cancelado = 3
    }
}
