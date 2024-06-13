using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    public class CEmpleado
    {
        internal ulong id;
        internal string? apellido;
        internal string? nombre;
        public ulong DarId()
        {
            return this.id;
        }
        public string? DarApellido()
        {
            return this.apellido;
        }

        public string? DarNombre()
        {
            return this.nombre;
        }
    }
}
