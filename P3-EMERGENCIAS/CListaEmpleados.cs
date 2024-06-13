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
        public void BuscarEmpleadoPorId(ulong idEmp)
        {
            JuntarListas();
            foreach(CEmpleado Empleado in TotalEmpleados)
            {
                Console.WriteLine(Empleado.DarId());
            }
        }
    }
}
