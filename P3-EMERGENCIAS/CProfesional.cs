﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    public class CProfesional : CEmpleado
    {
        private ushort matricula;
        private string categoria;
        public CProfesional(ulong idProf, string ape, string nom, string cat, ushort mat) {
            this.id = idProf;
            this.apellido = ape;
            this.nombre = nom;
            this.categoria = cat;
            this.matricula = mat;
        }

        public ushort DarMatricula()
        {
            return this.matricula;
        }

        public void DarDatos()
        {
            Console.WriteLine("\t {0}  {1}  {2}  {3}  {4}" , this.id , this.apellido , this.nombre , this.categoria , this.matricula);
        }
        public string DarCategoria()
        {
            return this.categoria;
        }
    }
}
