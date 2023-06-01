using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos.Contratos
{
    public class PedidoRespuesta
    {
        public PedidoEstadoContrato PedidoEstado { get; set; }
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
        public DateTime Entrega { get; set; }
    }
}
