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
        public void CargarProfesional(ulong idPro , string ape , string nom, ushort numMat , string cate)
        {
            CProfesional nuevoProfesional = new CProfesional(idPro, ape, nom, cate, numMat);
            ProfesionalesCollection.Add(nuevoProfesional);
        }
        public void CargarChofer(ulong idChof , string ape , string nom , uint reg , string distEm)
        {
            CChofer nuevoChofer = new CChofer(idChof, ape , nom , distEm , reg);
            ChoferCollection.Add(nuevoChofer);
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
        public void BuscarEmpleadoPorId(ulong idEmp)
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
                        return;
                    }
                }
            }
            TotalEmpleados.Clear();
            Console.WriteLine("No se encontro resultado");
        }
    }
}
