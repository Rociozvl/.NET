using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_reto_de_las_8_piezas
{
    internal class SinSolucionException :Exception
    {
        public SinSolucionException() : base("No se encontró una solución al problema de las piezas.") { }
    }
}
