using Contratos.Contratos;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoServicio _pedidoServicio;

        public PedidoController(IPedidoServicio pedidoServicio)
        {
            _pedidoServicio = pedidoServicio;
        }

        [HttpGet]
        [Route("VerPedido/{pedidoId}")]
        public async Task<PedidoRespuesta> VerPedido(int pedidoId)
        {
            return await _pedidoServicio.VerPedido(pedidoId);
        }

        [HttpPost]
        [Route("CrearPedido")]
        public async Task<string> CrearPedido(PedidoContrato pedidoContrato)
        {
            return await _pedidoServicio.CrearPedido(pedidoContrato);
        }
    }
}
