using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Pedido
    {
        public Pedido()
        {
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoId { get; set; }
        [Required]
        public int PedidoEstadoId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public PedidoEstado PedidoEstado { get; set; }
        [Required]
        [MaxLength(25)]
        [Column(TypeName = "varchar(200)")]
        public string NombreCliente { get; set; }
        [Required]
        [MaxLength(25)]
        [Column(TypeName = "varchar(25)")]
        public string Direccion { get; set; }
        [Required]
        public DateTime Entrega { get; set; }
    }
}
