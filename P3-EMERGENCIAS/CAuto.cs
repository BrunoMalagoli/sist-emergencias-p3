using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{   
    public class CAuto : CVehiculo
    {
        public CAuto(string pat, string mar , string mod ) {
            this.patente = pat;
            this.modelo = mod;
            this.marca = mar;
        }
        public void DarDatos()
        {
            Console.WriteLine("\t {0}  {1}  {2}", this.patente, this.marca, this.modelo);
        }

    }
}
