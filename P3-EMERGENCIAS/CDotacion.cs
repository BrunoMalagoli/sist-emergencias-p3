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
        public int DarCantidadProfesionales()
        {
            return listaIdProfesional.Count;
        }
        public void AsignarProfesionales()
        {
            string idProf;
            do
            {
                idProf = Console.ReadLine();
                Console.Write(">");
                Console.WriteLine("Asigne un profesional: ");
            } while (idProf != "0" && listaIdProfesional.Count != 0);
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
