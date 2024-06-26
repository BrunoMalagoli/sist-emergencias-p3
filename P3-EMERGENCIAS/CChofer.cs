﻿using Emergencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    public class CChofer : CEmpleado
    {
        private string distEmision;
        private uint numRegistro;
        
 
        public CChofer(ulong idChof , string ape , string nom , string dist , uint reg )
        {
            this.id = idChof;
            this.apellido = ape; 
            this.nombre = nom;   
            this.numRegistro = reg;
            this.distEmision = dist;
        }
        public void DarDatos()
        {
            Console.WriteLine("\t {0}  {1}  {2}  {3}  {4}", this.id, this.apellido, this.nombre, this.numRegistro, this.distEmision);
        }
        public string DarDistritoEmision()
        {
            return this.distEmision;
        }

        public uint DarNumRegistro()
        {
            return this.numRegistro;
        }
    }
}
