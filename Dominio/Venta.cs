using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int ID { get; set; }
        public Pedido pedido { get; set; }
        public float  ImporteTotal { get; set; }
        public string MetodoPago { get; set; }
        public DateTime FechaCierre { get; set; }
        public bool Activo { get; set; }

        public Venta()
        {
            pedido = new Pedido();
        }
    }
}
