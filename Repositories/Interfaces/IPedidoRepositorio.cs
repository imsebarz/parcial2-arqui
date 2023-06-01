using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IPedidoRepositorio
    {
        IQueryable<Pedido> ObtenerTodosLosPedidos();
        Task<Pedido> ObtenerPorId(int id);
        Task<Pedido> Crear(Pedido pedido);
        Task<Pedido> Actualizar(Pedido pedido);
        Task<Pedido> Eliminar(Pedido pedido);
    }
}
