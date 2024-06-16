using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    public class CAmbulancia : CVehiculo
    {
        private string tipoAmbulancia;
        public CAmbulancia(string pat, string mar, string mod, string tipoAm)
        {
            this.patente = pat;
            this.modelo = mod;
            this.marca = mar;
            tipoAmbulancia = tipoAm;
        }
        public void DarDatos()
        {
            Console.WriteLine("\t {0}  {1}  {2}  {3}", this.patente, this.marca, this.modelo, DarTipoAmbulancia());
        }
        public string DarTipoAmbulancia()
        {
            return this.tipoAmbulancia;
        }
    }
}
