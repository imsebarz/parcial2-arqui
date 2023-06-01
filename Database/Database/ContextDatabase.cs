using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Database
{
    public class ContextDatabase : DbContext
    {
        public IConfiguration Configuration { get; }

        public ContextDatabase(DbContextOptions<ContextDatabase> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("WebApplication1"));
            }
        }

        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<PedidoEstado> PedidoEstado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedido>(entity =>
            {
                //Table
                entity.ToTable("Pedido");

                //Columns
                entity.Property(x => x.PedidoId).HasColumnName("PedidoId");
                entity.Property(x => x.PedidoEstadoId).HasColumnName("PedidoEstadoId");
                entity.Property(x => x.NombreCliente).HasColumnName("NombreCliente");
                entity.Property(x => x.Direccion).HasColumnName("Direccion");
                entity.Property(x => x.Entrega).HasColumnName("Entrega");

                //ForeingKeys
                entity.HasOne(x => x.PedidoEstado).WithMany(x => x.Pedidos).HasForeignKey(x => x.PedidoEstadoId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PedidoEstado>(entity =>
            {
                //Table
                entity.ToTable("PedidoEstado");

                //Columns
                entity.Property(x => x.PedidoEstadoId).HasColumnName("PedidoEstadoId");
                entity.Property(x => x.Nombre).HasColumnName("Nombre");
            });
            modelBuilder.Entity<PedidoEstado>().HasData(new List<PedidoEstado> {
                new PedidoEstado
                {
                    PedidoEstadoId = 1,
                    Nombre = "Ingresado"
                },
                new PedidoEstado
                {
                    PedidoEstadoId = 2,
                    Nombre = "En procesamiento"
                },
                new PedidoEstado
                {
                    PedidoEstadoId = 3,
                    Nombre = "Despachado"
                },
                new PedidoEstado
                {
                    PedidoEstadoId = 4,
                    Nombre = "Entregado"
                }
            });
        }
    }
}
