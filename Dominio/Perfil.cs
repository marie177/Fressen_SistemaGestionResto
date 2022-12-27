using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Perfil
    {
        public int Id { get;set; }
        public string Nombre { get;set; }
    }

    public enum Perfiles
    {
        Gerente = 1,
        Mesero = 2
    }
}
