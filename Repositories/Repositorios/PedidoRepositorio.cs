using Database.Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private ContextDatabase _contextDatabase;

        public PedidoRepositorio(ContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        public IQueryable<Pedido> ObtenerTodosLosPedidos()
        {
            return _contextDatabase.Pedido.Include(x => x.PedidoEstado).AsQueryable();
        }

        public async Task<Pedido> ObtenerPorId(int id)
        {
            return _contextDatabase.Pedido.Include(x => x.PedidoEstado).FirstOrDefault(x => x.PedidoId == id);
        }

        public async Task<Pedido> Crear(Pedido pedido)
        {
            EntityEntry<Pedido> response = _contextDatabase.Pedido.Add(pedido);
            await _contextDatabase.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Pedido> Actualizar(Pedido pedido)
        {
            Pedido current = _contextDatabase.Pedido.FirstOrDefault(x => x.PedidoId == pedido.PedidoId);
            _contextDatabase.Entry(current).CurrentValues.SetValues(pedido);
            await _contextDatabase.SaveChangesAsync();
            return _contextDatabase.Pedido.Include(x => x.PedidoEstado).FirstOrDefault(x => x.PedidoId == pedido.PedidoId);
        }

        public async Task<Pedido> Eliminar(Pedido pedido)
        {
            EntityEntry<Pedido> response = _contextDatabase.Pedido.Remove(pedido);
            await _contextDatabase.SaveChangesAsync();
            return response.Entity;
        }
    }
}
