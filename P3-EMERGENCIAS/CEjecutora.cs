using System;

namespace Emergencias
{
    //ADVERTENCIA!!! SI QUIEREN ACCEDER A LAS LISTAS DE EMPLEADOS Y/O VEHICULOS ACCEDER A TRAVES DE METODOS DEL CMENU
    public class CEjecutora
    {
        
        public static void Main()
        {
            CMenu menu = new CMenu();
            menu.MostrarMenu();
        } 
    }
}

