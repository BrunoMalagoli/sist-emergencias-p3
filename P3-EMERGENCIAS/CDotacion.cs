using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    public class CDotacion
    {
        private static int acumDotId = 0;
        private int currDotId;
        private DateTime fecha;
        private string numPatente;
        private ulong idChofer;
        ArrayList listaIdProfesional;
        public CDotacion()
        {
            currDotId = ++acumDotId;
            listaIdProfesional = new ArrayList();
            fecha = DateTime.Now;
        }


        public void MostrarDotacion()
        {
            Console.WriteLine("\t {0}  {1}  {2}  {3}", this.currDotId, this.fecha, this.numPatente, this.idChofer);
            Console.Write("Lista de profesionales asignados: ");
            DarListaProfesionales();
        }
        public int DarCantidadProfesionales()
        {
            return listaIdProfesional.Count;
        }

        public void DarListaProfesionales()
        {
            foreach(ulong pro in listaIdProfesional)
            {
                Console.WriteLine($"\t{pro}");
            }
        }
        public void AsignarProfesionales()
        {
            string idProf;
            do
            {

                Console.WriteLine("Asigne un profesional (Ingrese 0 para dejar de cargar): ");
                Console.Write(">");
                idProf = Console.ReadLine();
                if ( idProf != "0")
                {
                    ulong idProfAux;
                    bool flag = ulong.TryParse(idProf, out idProfAux);

                    while (!flag)
                    {
                        Console.WriteLine("Ingrese dato valido");
                        flag = ulong.TryParse(idProf, out idProfAux);
                    }
                    listaIdProfesional.Add(idProfAux);
                    
                }
            } while (idProf != "0");
            return;
        }
        public void AsignarVehiculo()
        {
            string numP;
            if(listaIdProfesional.Count > 1)
            {
                Console.WriteLine("El numero de profesionales asignados a su dotacion es mayor a 1 , asigne una de las siguientes ambulancias:");         
                Console.Write(">");
                numP = Console.ReadLine();
                return;
            }
            Console.WriteLine("Asigne un auto a su dotacion: ");
            Console.Write(">");
            numP = Console.ReadLine();
            return;
        }

        public void AsignarChofer()
        {
            ulong idC;
            bool flag;
            Console.WriteLine("Asigne el chofer por ID: ");
            Console.Write(">");
            flag = ulong.TryParse(Console.ReadLine(), out idC);
              while(!flag)
                {
                    Console.WriteLine("Ingrese un dato valido:");
                    flag = ulong.TryParse(Console.ReadLine(), out idC);
              }  
            idChofer = idC;
            return;
        }


    }
}
