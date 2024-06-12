using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    internal class CAmbulancia : CVehiculo
    {
        internal string _tipoAmbulancia;
        public CAmbulancia(string pat, string mar, string mod, string tipoAmbulancia)
        {
            this.patente = pat;
            this.modelo = mod;
            this.marca = mar;
            _tipoAmbulancia = tipoAmbulancia;
        }

    }
}
