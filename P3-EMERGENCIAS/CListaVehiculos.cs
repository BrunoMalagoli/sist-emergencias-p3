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
        private static ArrayList AutosCollection;
        private static ArrayList AmbulanciasCollection;
        private static ArrayList TotalVehiculos;
        public CListaVehiculos()
        {
            AutosCollection = new ArrayList();
            AmbulanciasCollection = new ArrayList();
            TotalVehiculos = new ArrayList();
        }
        public bool ExisteAutoEnCollection(string patente)
        {
            foreach (CAuto auto in AutosCollection)
            {
                if (auto.DarPatente() == patente)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ExisteAmbulanciaEnCollection(string patente)
        {
            foreach (CAmbulancia auto in AmbulanciasCollection)
            {
                if (auto.DarPatente() == patente)
                {
                    return true;
                }
            }
            return false;
        }
        public void CargarAuto(string patente, string modelo, string marca)
        {
            if (!ExisteAutoEnCollection(patente))
            {
                CAuto AutoInstancia = new CAuto(patente, marca, modelo);
                AutosCollection.Add(AutoInstancia);
            }
            else Console.WriteLine("El Vehiculo con patente {0} ya esta cargado", patente);
        }
        public void CargarAmbulancia(string patente, string modelo, string marca, string tipo)
        {
            if (!ExisteAmbulanciaEnCollection(patente))
            {
                CAmbulancia AmbulanciaInstancia = new CAmbulancia(patente, modelo, marca, tipo);
                AmbulanciasCollection.Add(AmbulanciaInstancia);
            }
            else Console.WriteLine("El Vehiculo con patente {0} ya esta cargado", patente);
        }
        private void MostrarDatosVehiculo(CAuto auto)
        {
            Console.WriteLine("{0}    {1}    {2}  ", auto.DarPatente() , auto.DarMarca() , auto.DarModelo());
        }
        private void MostrarDatosVehiculo(CAmbulancia ambu)
        {
            Console.WriteLine("{0}    {1}    {2}    {3}", ambu.DarPatente() , ambu.DarMarca() , ambu.DarModelo() , ambu.DarTipoAmbulancia() );
        }
        private void JuntarListas()
        {
            TotalVehiculos.AddRange(AmbulanciasCollection);
            TotalVehiculos.AddRange(AutosCollection);
        }

        public void MostrarTodosVehiculos()
        {
            JuntarListas();
            foreach (object vehiculo in TotalVehiculos)
            {
                if (vehiculo is CAuto)
                {
                    MostrarDatosVehiculo((CAuto)vehiculo);
                }
                else if (vehiculo is CAmbulancia)
                {
                    MostrarDatosVehiculo((CAmbulancia)vehiculo);
                }
            }
        }

        //METODOS PARA TESTEAR
        internal void MostrarListaAutos()
        {
            Console.WriteLine("Lista de autos: ");
            foreach (CAuto Auto in AutosCollection)
            {
                Auto.DarDatos();
            }
        }
        internal void MostrarListaAmbulancias()
        {
            Console.WriteLine("Lista de ambulancias: ");
            foreach (CAmbulancia Ambu in AmbulanciasCollection)
            {
                Ambu.DarDatos();
            }
        }
    }
}
