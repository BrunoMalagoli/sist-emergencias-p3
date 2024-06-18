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
            CProfesional nuevoProfesional = new CProfesional(idPro, ape, nom, cate, numMat);
            foreach (CProfesional profesional in ProfesionalesCollection)
            {
                if (profesional.DarMatricula() == numMat || profesional.DarId() == idPro)
                {   
                    Console.WriteLine("\n\tLa matrícula o el número de Id del profesional ya existe."); // TODO: Este aviso es sólo para nosotros, la responsabilidad de informar es de Vmenu. 
                    Console.Write("Presione Enter para continuar...");
                    Console.ReadLine();
                    return false;
                }
            }
            ProfesionalesCollection.Add(nuevoProfesional);
            return true;
        }
        public bool CargarChofer(ulong idChof , string ape , string nom , uint reg , string distEm)
        {
            CChofer nuevoChofer = new CChofer(idChof, ape , nom , distEm , reg);
            foreach (CChofer chofer in ChoferCollection)
            {
                if (chofer.DarNumRegistro() == reg || chofer.DarId() == idChof)
                {
                    Console.WriteLine("\n\tEl registro o el número de Id del chofer ya existe."); // TODO: Este aviso es sólo para nosotros, la responsabilidad de informar es de Vmenu.
                    Console.Write("Presione Enter para continuar...");
                    Console.ReadLine();
                    return false;
                }
            }
            ChoferCollection.Add(nuevoChofer);
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

        public void MostrarListaEmpleados()
        {
            JuntarListas();
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}","ID", "APELLIDO", "NOMBRE", "MAT/REG", "CAT/DIST");
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
        public void BuscarEmpleadoPorId(ulong idEmp) // TODO : OPTIMIZAR BUSQUEDA.
        {
            JuntarListas();
            foreach(object empleado in TotalEmpleados)
            {
                if(empleado is CChofer)
                {
                    if(idEmp == ((CChofer)empleado).DarId()){
                        Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}",
                            ((CChofer)empleado).DarId().ToString(), 
                            ((CChofer)empleado).DarNombre(), 
                            ((CChofer)empleado).DarApellido(), 
                            ((CChofer)empleado).DarNumRegistro().ToString(), 
                            ((CChofer)empleado).DarDistritoEmision());
                        TotalEmpleados.Clear();
                        return;
                    }
                }else if(empleado is CProfesional)
                {
                    if (idEmp == ((CProfesional)empleado).DarId())
                    {
                        Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}",
                            ((CProfesional)empleado).DarId().ToString(), 
                            ((CProfesional)empleado).DarNombre(), 
                            ((CProfesional)empleado).DarApellido(), 
                            ((CProfesional)empleado).DarMatricula().ToString(), 
                            ((CProfesional)empleado).DarCategoria()); 
                        TotalEmpleados.Clear();  
                        return;
                    }
                }
            }
            TotalEmpleados.Clear();
            Console.WriteLine("No se encontro resultado");
        }
    }
}
