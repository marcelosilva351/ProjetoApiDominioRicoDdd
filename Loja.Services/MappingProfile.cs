using AutoMapper;
using Loja.Dominio.Dto_s.ClientesDTOS;
using Loja.Dominio.Dto_s.PedidosDTOS;
using Loja.Dominio.Dto_s.ProdutosDTOS;
using Loja.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProdutoDTO, Produto>();
            CreateMap<CreatePedidoDTO, Pedido>();
            CreateMap<CreateClienteDTO, Client>();
        }
    }
}
