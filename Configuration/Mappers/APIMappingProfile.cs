using AutoMapper;
using Contratos.Contratos;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Mappers
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<PedidoRespuesta, Pedido>().ReverseMap();
            CreateMap<PedidoContrato, Pedido>().ReverseMap();
            CreateMap<PedidoEstadoContrato, PedidoEstado>().ReverseMap();
        }
    }
}
