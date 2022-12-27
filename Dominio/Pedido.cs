using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int ID { get; set; }
        public Mesa Mesa { get; set; }

        public Usuario MeseroAsignado { get; set; }
        public List<DetallePedido> ListDetallePedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public bool Entregado { get; set; }
        public decimal Total { get; set; }

        public Pedido()
        {
            ListDetallePedido = new List<DetallePedido>();
        }
    }
}
