using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class PedidoEstado
    {
        public PedidoEstado()
        {
            Pedidos = new HashSet<Pedido>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoEstadoId { get; set; }
        [Required]
        [MaxLength(25)]
        [Column(TypeName = "varchar(25)")]
        public string Nombre { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
