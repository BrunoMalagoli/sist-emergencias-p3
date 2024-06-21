using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    public class CListaEmpleados
    {
        private static ArrayList ChoferCollection;
        private static ArrayList ProfesionalesCollection;
        private static ArrayList TotalEmpleados;

        public CListaEmpleados()
        {
            ChoferCollection = new ArrayList();
            ProfesionalesCollection = new ArrayList();
            TotalEmpleados = new ArrayList();
        }
        private void JuntarListas()
        {
            TotalEmpleados.AddRange(ChoferCollection);
            TotalEmpleados.AddRange(ProfesionalesCollection);
        }

        public bool CargarProfesional(ulong idPro , string ape , string nom, ushort numMat , string cate)
        {
            JuntarListas();
            CProfesional nuevoProfesional = new CProfesional(idPro, ape, nom, cate, numMat);
            foreach (CEmpleado empleado in TotalEmpleados)
            {
                if ( empleado.DarId() == idPro)
                {   
                    //NO SE AGREGA EL PROFESIONAL PORQUE YA ESTA EN LA LISTA
                    Console.Write("Presione Enter para continuar...");
                    Console.ReadLine();
                    return false;
                }
            }
            ProfesionalesCollection.Add(nuevoProfesional);
            TotalEmpleados.Clear();
            return true;
        }
        public bool CargarChofer(ulong idChof , string ape , string nom , uint reg , string distEm)
        {
            CChofer nuevoChofer = new CChofer(idChof, ape , nom , distEm , reg);
            foreach (CEmpleado empleado in TotalEmpleados)
            {
                if (empleado.DarId() == idChof)
                {
                    Console.WriteLine("\n\tEl registro o el número de Id del chofer ya existe."); // TODO: Este aviso es sólo para nosotros, la responsabilidad de informar es de Vmenu.
                    Console.Write("Presione Enter para continuar...");
                    Console.ReadLine();
                    return false;
                }
            }
            ChoferCollection.Add(nuevoChofer);
            TotalEmpleados.Clear();
            return true;
        }
        private void MostrarDatosEmpleado(CChofer empleadoChof)
        {
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}",
                empleadoChof.DarId().ToString(), 
                empleadoChof.DarApellido(), 
                empleadoChof.DarNombre(), 
                empleadoChof.DarNumRegistro().ToString(),
                empleadoChof.DarDistritoEmision());
        }
        private void MostrarDatosEmpleado(CProfesional empleadoPro)
        {
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}", 
                empleadoPro.DarId().ToString(), 
                empleadoPro.DarApellido(), 
                empleadoPro.DarNombre(), 
                empleadoPro.DarMatricula().ToString(), 
                empleadoPro.DarCategoria());
        }

        public void EliminarChofer(ulong idChof )
        {
            foreach(CChofer chofer in ChoferCollection)
            {
                if(chofer.DarId() == idChof)
                {
                    ChoferCollection.Remove(chofer);
                    Console.WriteLine("Se elimino el chofer {0}" , idChof);
                    return;
                }
            }
            Console.WriteLine("No se encontro el chofer para eliminar");
        }
        public void EliminarProfesional(ulong idPro) 
        {
            foreach (CProfesional pro in ProfesionalesCollection)
            {
                if (pro.DarId() == idPro)
                {
                    ChoferCollection.Remove(pro);
                    Console.WriteLine("Se elimino el profesional {0}", idPro);
                    return;
                }
            }
            Console.WriteLine("No se encontro el profesional para eliminar");
        }
        public void MostrarListaEmpleados() // corregido cuando no hay empleados en la lista
        {
            JuntarListas();
            OrdenarListaEmpleados(TotalEmpleados);

            if (TotalEmpleados.Count != 0)
            {
                Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}", "ID", "APELLIDO", "NOMBRE", "MAT/REG", "CAT/DIST");
                foreach (object empleado in TotalEmpleados)
                {
                    if (empleado is CChofer)
                    {
                        MostrarDatosEmpleado((CChofer)empleado);
                    }
                    else
                    {
                        MostrarDatosEmpleado((CProfesional)empleado);
                    }

                }
                TotalEmpleados.Clear();
            }
            else {
                Console.WriteLine("\t{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}", "ID", "APELLIDO", "NOMBRE", "MAT/REG", "CAT/DIST");
                Console.WriteLine("\tNo hay empleados cargados en la lista"); }

        }
        public void MostrarChoferes()
        {
            foreach(object chofer in ChoferCollection)
            {
                if (chofer is CChofer)
                {
                    MostrarDatosEmpleado((CChofer)chofer);
                }
            }
            return;
        }

        public void MostrarProfesionales()
        {
            foreach(object profesional in ProfesionalesCollection)
            {
                if (profesional is CProfesional)
                {
                    MostrarDatosEmpleado((CProfesional)profesional);
                }
            }
            return;
        }
        public bool BuscarEmpleadoPorId(ulong idEmp) // TODO : OPTIMIZAR BUSQUEDA.
        {
            JuntarListas();
            foreach(object empleado in TotalEmpleados)
            {
                if(empleado is CChofer)
                {
                    if(idEmp == ((CChofer)empleado).DarId()){
                        Console.WriteLine("Chofer: {0,-10}{1,-10}{2,-10}{3,-10}{4,-10}",
                            ((CChofer)empleado).DarId().ToString(), 
                            ((CChofer)empleado).DarNombre(), 
                            ((CChofer)empleado).DarApellido(), 
                            ((CChofer)empleado).DarNumRegistro().ToString(), 
                            ((CChofer)empleado).DarDistritoEmision());
                            TotalEmpleados.Clear();
                        return true;
                    }
                }else if(empleado is CProfesional)
                {
                    if (idEmp == ((CProfesional)empleado).DarId())
                    {
                        Console.WriteLine("Profesional: {0,-10}{1,-10}{2,-10}{3,-10}{4,-10}",
                            ((CProfesional)empleado).DarId().ToString(), 
                            ((CProfesional)empleado).DarNombre(), 
                            ((CProfesional)empleado).DarApellido(), 
                            ((CProfesional)empleado).DarMatricula().ToString(), 
                            ((CProfesional)empleado).DarCategoria()); 
                        TotalEmpleados.Clear();  
                        return true;
                    }
                }
            }
            TotalEmpleados.Clear();
            Console.WriteLine("No se encontro resultado");
            return false;
        }

        public void OrdenarListaEmpleados(ArrayList listaEmp)
        {

            /*
            Para utilizar este metodo primero hay que llamar al metodo: JuntarListas().
            */
            int n = TotalEmpleados.Count;


            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare((TotalEmpleados[j] as CEmpleado).DarApellido(), (TotalEmpleados[j + 1] as CEmpleado).DarApellido(), StringComparison.Ordinal) > 0)         
                    {
                        // Intercambiar list[j] y list[j + 1]
                        object temp = TotalEmpleados[j];
                        TotalEmpleados[j] = TotalEmpleados[j + 1];
                        TotalEmpleados[j + 1] = temp;
                    }
                    else if (string.Compare((TotalEmpleados[j] as CEmpleado).DarApellido(), (TotalEmpleados[j + 1] as CEmpleado).DarApellido(), StringComparison.Ordinal) == 0)
                    {
                        if (string.Compare((TotalEmpleados[j] as CEmpleado).DarNombre(), (TotalEmpleados[j + 1] as CEmpleado).DarNombre(), StringComparison.Ordinal) > 0)
                        {
                            // Intercambiar list[j] y list[j + 1]
                            object temp = TotalEmpleados[j];
                            TotalEmpleados[j] = TotalEmpleados[j + 1];
                            TotalEmpleados[j + 1] = temp;
                        }
                        else if (string.Compare((TotalEmpleados[j] as CEmpleado).DarNombre(), (TotalEmpleados[j + 1] as CEmpleado).DarNombre(), StringComparison.Ordinal) == 0)
                        {
                            if ((TotalEmpleados[j] as CEmpleado).DarId() > (TotalEmpleados[j+1] as CEmpleado).DarId())
                            {
                                // Intercambiar list[j] y list[j + 1]
                                object temp = TotalEmpleados[j];
                                TotalEmpleados[j] = TotalEmpleados[j + 1];
                                TotalEmpleados[j + 1] = temp;
                            }
                        }
                    }
                }
            }
        }
    }
}
