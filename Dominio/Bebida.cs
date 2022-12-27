using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Bebida : Insumo
    {
        public float Capacidad { get; set; }
        public Marca Marca { get; set; }
        public bool Alcoholica { get; set; }

        public string Detalle { get; set; }
    }
}
