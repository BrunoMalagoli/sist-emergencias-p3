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
        public void CargarAuto(string patente, string modelo, string marca)
        {
            CAuto AutoInstancia = new CAuto(patente , marca, modelo);
            AutosCollection.Add(AutoInstancia);
        }
        public void CargarAmbulancia( string patente , string modelo, string marca , string tipo)
        {
            CAmbulancia AmbulanciaInstancia = new CAmbulancia(patente , modelo, marca , tipo);
            AmbulanciasCollection.Add(AmbulanciaInstancia);
        }
        private void MostrarDatosVehiculo(CAuto auto)
        {
            Console.WriteLine("{0,-12}{1,-12}{2,-12}  ", auto.DarPatente() , auto.DarMarca() , auto.DarModelo());
        }
        private void MostrarDatosVehiculo(CAmbulancia ambu)
        {
            Console.WriteLine("{0,-12}{1,-12}{2,-12}{3,-12}", ambu.DarPatente() , ambu.DarMarca() , ambu.DarModelo() , ambu.DarTipoAmbulancia() );
        }
        private void JuntarListas()
        {
            TotalVehiculos.AddRange(AmbulanciasCollection);
            TotalVehiculos.AddRange(AutosCollection);
        }

        private void OrdenarListas()
        {
            // TotalVehiculos.AddRange(AmbulanciasCollection);
            // TotalVehiculos.AddRange(AutosCollection);
            /*
            Para utilizar este metodo primero hay que llamar al metodo: JuntarListas().
            */
            int n = TotalVehiculos.Count;


            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    
                    // string patente1 = TotalVehiculos[j].DarPatente();
                    // string patente2 = TotalVehiculos[j+1].DarPatente();
                    if (string.Compare( (TotalVehiculos[j] as CVehiculo).DarPatente(),(TotalVehiculos[j+1] as CVehiculo).DarPatente() , StringComparison.Ordinal) > 0)
                    {
                        // Intercambiar list[j] y list[j + 1]
                        object temp = TotalVehiculos[j];
                        TotalVehiculos[j] = TotalVehiculos[j + 1];
                        TotalVehiculos[j + 1] = temp;
                    }
                }
            }
        }

        public void MostrarTodosVehiculos()
        {
            JuntarListas();
            OrdenarListas();

            Console.WriteLine("{0,-12}{1,-12}{2,-12}{3,-12}  ", "PATENTE", "MARCA", "MODELO", "TIPO");

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
            TotalVehiculos.Clear();
        }

        //METODOS PARA TESTEAR
        internal void MostrarListaAutos()
        {
            Console.WriteLine("{0,-12}{1,-12}{2,-12}  ", "PATENTE", "MARCA", "MODELO");
            foreach (CAuto Autos in AutosCollection)
            {
                Console.WriteLine("{0,-12}{1,-12}{2,-12}  ", Autos.DarPatente(), Autos.DarMarca(), Autos.DarModelo());
            }
        }
        internal void MostrarListaAmbulancias()
        {
            Console.WriteLine("{0,-12}{1,-12}{2,-12}{3,-12}  ", "PATENTE", "MARCA", "MODELO","TIPO");
            foreach (CAmbulancia Ambu in AmbulanciasCollection)
            {
                Console.WriteLine("{0,-12}{1,-12}{2,-12}{3,-12}  ", Ambu.DarPatente(), Ambu.DarMarca(), Ambu.DarModelo(),Ambu.DarTipoAmbulancia());
            }
        }
    }

}
