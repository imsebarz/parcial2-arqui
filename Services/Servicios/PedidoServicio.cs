using AutoMapper;
using Contratos.Contratos;
using Database.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicios
{
    public class PedidoServicio : IPedidoServicio
    {
        private readonly IMapper _mapper;
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidoServicio(IMapper mapper, IPedidoRepositorio pedidoRepositorio)
        {
            _mapper = mapper;
            _pedidoRepositorio = pedidoRepositorio;
        }

        public async Task<PedidoRespuesta> VerPedido(int pedidoId)
        {
            Pedido pedido = await _pedidoRepositorio.ObtenerPorId(pedidoId);
            if (pedido == null)
                throw new ArgumentException("Error al buscar el pedido.");

            return _mapper.Map<PedidoRespuesta>(pedido);
        }

        public async Task<string> CrearPedido(PedidoContrato pedidoContrato)
        {
            Pedido pedido = _mapper.Map<Pedido>(pedidoContrato);
            pedido.PedidoEstadoId = 1;
            pedido.Entrega = DateTime.Now;

            Pedido respuesta = await _pedidoRepositorio.Crear(pedido);
            if (respuesta == null)
                throw new ArgumentException("Error al crear el pedido.");

            return $"Su pedido ha sido recibido. Aquí puede ver su pedido: \n" +
                $"https://localhost:5001/Pedido/VerPedido/{respuesta.PedidoId}";
        } 
    }
}
