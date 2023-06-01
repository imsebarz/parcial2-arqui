using Contratos.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPedidoServicio
    {
        Task<PedidoRespuesta> VerPedido(int pedidoId);
        Task<string> CrearPedido(PedidoContrato pedidoContrato);
    }
}
