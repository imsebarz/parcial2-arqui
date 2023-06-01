using Database.Database;
using Database.Models;
using System;
using System.Linq;

namespace Interfaces.Repositorios
{
    public interface IClienteRepositorio
    {
        IQueryable<Cliente> ObtenerTodosLosClientes();
    }
}
