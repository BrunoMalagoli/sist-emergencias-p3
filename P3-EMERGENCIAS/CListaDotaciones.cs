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

        public void DarDotaciones()
        {
            foreach(CDotacion dota in ColeccionDotaciones)
            {
                dota.MostrarDotacion();
            }
        }

        public bool AgregarDotacion(CDotacion dotacionRef)
        {
            
            if (!ExisteVehiculoEnDotacion(dotacionRef.DarPatenteVehiculo()) && !ExisteChoferEnDotacion(dotacionRef.DarChoferId()) && !ExisteProfesionalesEnDotaciones(dotacionRef.DarListaProfesionales())) {
                ColeccionDotaciones.Add(dotacionRef);
                return true;
            }
            else
            {
                return false;
            }
               
        }
        public bool ExisteProfesionalesEnDotaciones(ArrayList profIdList)
        {
            foreach (CDotacion dota in ColeccionDotaciones)
            {
                foreach (ulong id in dota.DarListaProfesionales())
                {
                    if (profIdList.Contains(id))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool ExisteProfesionalesEnDotaciones(ulong profId)
        {
            foreach (CDotacion dota in ColeccionDotaciones)
            {
                foreach (ulong id in dota.DarListaProfesionales())
                {
                    if (profId == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool ExisteChoferEnDotacion(ulong choferID)
        {
            foreach (CDotacion dota in ColeccionDotaciones)
            {
                if(dota.DarChoferId() == choferID)
                {
                    return true;    
                }
            }
            return false;
        }
        public static bool ExisteVehiculoEnDotacion(string numpat)
        {
            foreach(CDotacion dota in ColeccionDotaciones)
            {
                if(dota.DarPatenteVehiculo() == numpat)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
