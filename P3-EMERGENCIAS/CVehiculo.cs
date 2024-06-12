using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    public class CVehiculo 
    {
        internal string? patente;
        internal string? marca;
        internal string? modelo;
        public string DarPatente()
        {
            if (patente == null)
            {
                return "No se proporicono una patente";
            }
            return patente;
        }
        public string DarMarca()
        {
            if (marca == null)
            {
                return "No se proporicono una marca";
            }
            return marca;
        }
        public string DarModelo()
        {
            if (modelo == null)
            {
                return "No se proporicono una modelo";
            }
            return modelo;
        }
    }

}
