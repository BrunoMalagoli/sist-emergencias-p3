using System;
using System.Collections;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    public class CListaVehiculos
    {
        private static ArrayList AutosCollection = new ArrayList();
        private static ArrayList AmbulanciasCollection = new ArrayList();
        
        internal void CargarAuto(string patente, string modelo, string marca)
        {
            CAuto AutoInstancia = new CAuto(patente , marca, modelo);
            AutosCollection.Add(AutoInstancia);
        }
        internal void CargarAmbulancia( string patente , string modelo, string marca , string tipo)
        {
            CAmbulancia AmbulanciaInstancia = new CAmbulancia(patente , modelo, marca , tipo);
            AmbulanciasCollection.Add(AmbulanciaInstancia);
        }
        internal void MostrarListaAutos()
        {
            foreach (CAuto Autos in AutosCollection)
            {
                Console.WriteLine(Autos.patente);
                Console.WriteLine(Autos.marca);
                Console.WriteLine(Autos.modelo);
            }
        }
        internal void MostrarListaAmbulancias()
        {
            foreach (CAmbulancia Ambu in AmbulanciasCollection)
            {
                Console.WriteLine(Ambu._tipoAmbulancia);
                Console.WriteLine(Ambu.patente);
                Console.WriteLine(Ambu.marca);
                Console.WriteLine(Ambu.modelo);
            }
        }
    }
}
