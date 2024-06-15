using Emergencias;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    public class CListaDotaciones
    {
        private static ArrayList ColeccionDotaciones;
        public CListaDotaciones() {
             ColeccionDotaciones = new ArrayList();
        }

        public void AgregarDotacion(CDotacion dotacionRef)
        {
            ColeccionDotaciones.Add(dotacionRef);
        }

    }
}
