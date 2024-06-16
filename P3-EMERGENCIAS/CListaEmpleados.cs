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
            Console.WriteLine("{0}    {1}    {2}    {3}    {4}" , empleadoChof.DarId() , empleadoChof.DarApellido() , empleadoChof.DarNombre(), empleadoChof.DarNumRegistro(), empleadoChof.DarDistritoEmision());
        }
        private void MostrarDatosEmpleado(CProfesional empleadoPro)
        {
            Console.WriteLine("{0}    {1}    {2}    {3}    {4}", empleadoPro.DarId(), empleadoPro.DarApellido(), empleadoPro.DarNombre(), empleadoPro.DarMatricula(), empleadoPro.DarCategoria());
        }

        public void MostrarListaEmpleados()
        {
            JuntarListas();
            Console.WriteLine("ID    APELLIDO    NOMBRE    MAT/REG    CAT/DIST");
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
            Console.WriteLine("Lista de choferes : ");
            foreach(CChofer chofer in ChoferCollection)
            {
                chofer.DarDatos();
            }
            return;
        }

        public void MostrarProfesionales()
        {
            Console.WriteLine("Lista de profesionales : ");
            foreach (CProfesional pro in ProfesionalesCollection)
            {
                pro.DarDatos();
            }
            return;
        }
        public void BuscarEmpleadoPorId(ulong idEmp)
        {
            JuntarListas();
            foreach(object empleado in TotalEmpleados)
            {
                if(empleado is CChofer)
                {
                    if(idEmp == ((CChofer)empleado).DarId()){
                        Console.WriteLine("{0}   {1}   {2}   {3}   {4}", ((CChofer)empleado).DarId(), ((CChofer)empleado).DarNombre(), ((CChofer)empleado).DarApellido(), ((CChofer)empleado).DarNumRegistro(), ((CChofer)empleado).DarDistritoEmision());
                        return;
                    }
                }else if(empleado is CProfesional)
                {
                    if (idEmp == ((CProfesional)empleado).DarId())
                    {
                        Console.WriteLine("{0}   {1}   {2}   {3}   {4}", ((CProfesional)empleado).DarId(), ((CProfesional)empleado).DarNombre(), ((CProfesional)empleado).DarApellido(), ((CProfesional)empleado).DarMatricula(), ((CProfesional)empleado).DarCategoria());
                        return;
                    }
                }
            }
            Console.WriteLine("No se encontro resultado");
        }
    }
}
