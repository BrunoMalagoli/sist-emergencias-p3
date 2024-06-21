using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    public class CMenu
    {
        private CListaVehiculos listaVehiculos;
        private CListaEmpleados listaEmpleados;
        private CListaDotaciones listaDotaciones;
   
        public CMenu()
        {
            listaVehiculos = new CListaVehiculos();
            listaEmpleados = new CListaEmpleados();
            listaDotaciones = new CListaDotaciones();
        }

        public void MostrarMenu()
        {
            string? opMenu;
            Console.WriteLine("\t===============================");
            Console.WriteLine("\t1.Desea cargar empleados?");
            Console.WriteLine("\t2.Desea cargar vehiculos?");
            Console.WriteLine("\t3.Asignar Dotacion");
            Console.WriteLine("\t4.Buscar empleado por ID");
            Console.WriteLine("\t5.Mostrar todos los empleados");
            Console.WriteLine("\t6.Mostrar todos los vehiculos");
            Console.WriteLine("\t7.Eliminar empleado por id");
            Console.WriteLine("\t8.Mostrar dotacion por patente");
            Console.WriteLine("\t0.Salir");
            Console.WriteLine("\t===============================");
            Console.Write("\t>");
            opMenu = Console.ReadLine();
            if (opMenu != null && opMenu != "0")
            {
                ManejarMenu(opMenu);
            }
            else
            {
                if (opMenu == "0")
                {
                    Console.WriteLine("Hasta la proxima!");
                    Console.WriteLine("Presione Enter para finalizar...");
                    Console.ReadLine();
                }
            }
        }

        private void ManejarMenu(string selMenu)
        {
            switch (selMenu)
            {
                case "1":
                    //Menu carga datos empleados
                    ulong codIdentPersonal;
                    string? apellido;
                    string? nombre;
                    string? ocupacion;

                    //Chofer
                    uint numRegistroConducir;
                    string? distritoEmisionReg;

                    //Profesional
                    ushort numMatricula;
                    string? categoria;

                    Console.Write("Ingrese Codigo de Identificacion Personal : ");  //Creacion secuencial cada vez que ingrese uno nuevo o manual por el usuario?
                    //ulong.TryParse(Console.ReadLine(), out codIdentPersonal);      //COMPROBACION TRYPARSE  
                    while(!ulong.TryParse(Console.ReadLine(), out codIdentPersonal))//COMPROBACION TRYPARSE  
                    {
                        Console.WriteLine("El código ingresado no es válido, debe ser numérico. Reintentando.");
                        Console.Write("Ingrese Codigo de Identificacion Personal : ");

                    }
                    Console.Write("Ingrese Apellido : ");
                    apellido = Console.ReadLine();
                    Console.Write("Ingrese Nombre : ");
                    nombre = Console.ReadLine();
                    Console.WriteLine("Seleccione su ocupacion : ");
                    Console.WriteLine("\t1. Chofer");
                    Console.WriteLine("\t2. Profesional");
                    Console.Write(">");
                    ocupacion = Console.ReadLine();
                    switch (ocupacion)
                    {

                        case "1":
                            Console.Write("Num Registro de Conducir : ");
                            while(!uint.TryParse(Console.ReadLine(), out numRegistroConducir)) //COMPROBACION TRYPARSE
                            { 
                                Console.WriteLine("Registro de conducir no válido. Debe ser numérico. Reintentando.");
                                Console.Write("Num Registro de Conducir : ");
                            }
                            //uint.TryParse(Console.ReadLine(), out numRegistroConducir);      //COMPROBACION TRYPARSE
                            Console.Write("Distrito de Emision de Registro Conducir : ");
                            distritoEmisionReg = Console.ReadLine();
                            listaEmpleados.CargarChofer(codIdentPersonal, apellido, nombre, numRegistroConducir, distritoEmisionReg);
                            break;
                        case "2":
                            Console.Write("Num Matricula : ");
                            bool parsed = ushort.TryParse(Console.ReadLine(), out numMatricula); //COMPROBACION TRYPARSE
                            while(!parsed){
                                Console.WriteLine("Número de Matrícula erróneo (supera 65535). Reintentando.");
                                Console.Write("Num Matrícula:");
                                parsed = ushort.TryParse(Console.ReadLine(), out numMatricula); //NUEVA COMPROBACION TRYPARSE
                            }

                            do
                            {
                                Console.WriteLine("Seleccione su Categoria : ");
                                Console.WriteLine("\t1. Medico");
                                Console.WriteLine("\t2. Enfermero");
                                Console.WriteLine("\t3. Paramedico");
                                Console.Write(">");
                                categoria = Console.ReadLine();
                                switch (categoria)
                                {
                                    case "1":
                                        categoria = "Medico";
                                        break;
                                    case "2":
                                        categoria = "Enfermero";
                                        break;
                                    case "3":
                                        categoria = "Paramedico";
                                        break;
                                    default:
                                        categoria = null;
                                        break;
                                }
                            } while (categoria == null);
                            if(listaEmpleados.CargarProfesional(codIdentPersonal, apellido, nombre, numMatricula, categoria))
                            {
                                Console.WriteLine("Profesional agregado correctamente");
                                
                            }
                            else
                            {
                                Console.WriteLine("El Profesional ya existe en la lista");
                                
                            }
                            break;
                            
                    }
                    break;


                case "2":
                    //Metodo carga datos vehiculos (Elegir vehiculo ListaVehiculos)
                    string? opVehiculo;
                    Console.WriteLine("Que tipo de vehiculo desea cargar?");
                    Console.WriteLine("\t1.Auto");
                    Console.WriteLine("\t2.Ambulancia");
                    Console.Write(">");
                    opVehiculo = Console.ReadLine();
                    if (opVehiculo == "1")
                    {
                        Console.WriteLine("Estas cargando un Auto");
                        string? patente;
                        string? modelo;
                        string? marca;
                        do
                        {
                            Console.Write("Patente : ");
                            patente = Console.ReadLine();
                            Console.Write("Marca : ");
                            marca = Console.ReadLine();
                            Console.Write("Modelo: ");
                            modelo = Console.ReadLine();
                        } while (patente == null || marca == null || modelo == null);
                        
                        if (listaVehiculos.CargarAuto(patente, modelo, marca))
                        {
                            Console.WriteLine("Auto cargado correctamente");
                        }
                        else
                        {
                            Console.WriteLine("El auto ya existe en el programa");
                            Console.WriteLine("Pulse enter para continuar...");
                            Console.Read();
                        }
                    }
                    else if (opVehiculo == "2")
                    {
                        Console.WriteLine("Estas cargando una Ambulancia");
                        string? patente;
                        string? modelo;
                        string? marca;
                        string? tipo;
                        //MENU TIPOS AMBULANCIAS ?? 
                        do
                        {
                            Console.Write("Tipo de ambulancia : ");
                            Console.WriteLine("1.EMG  2.UTIM  3.UCM");
                            tipo = Console.ReadLine();
                            switch (tipo)
                            {
                                case "1":
                                    tipo = "EMG";
                                    break;
                                case "2":
                                    tipo = "UTIM";
                                    break;
                                case "3":
                                    tipo = "UCM";
                                    break;
                                default: 
                                    Console.WriteLine("Tipo de ambulancia invalido , intentelo nuevamente");
                                    MostrarMenu();
                                    break;
                            }  
                            Console.Write("Patente : ");
                            patente = Console.ReadLine();
                            Console.Write("Marca : ");
                            marca = Console.ReadLine();
                            Console.Write("Modelo: ");
                            modelo = Console.ReadLine();
                        } while (patente == null || marca == null || modelo == null || tipo == null);
                        if(listaVehiculos.CargarAmbulancia(patente, modelo, marca, tipo))
                        {
                            Console.WriteLine("Ambulancia cargada correctamente");
                        }
                        else
                        {
                            Console.WriteLine("La ambulancia ya existe en el programa");
                            Console.WriteLine("Pulse enter para continuar...");
                            Console.Read();
                        }
                    }
                    break;
                case "3":
     
                    CDotacion nuevaDotacion = new CDotacion();
                    listaEmpleados.MostrarChoferes();
                    nuevaDotacion.AsignarChofer();
                    listaEmpleados.MostrarProfesionales();
                    nuevaDotacion.AsignarProfesionales();
                    if(nuevaDotacion.DarCantidadProfesionales() > 1)
                    {
                        listaVehiculos.MostrarListaAmbulancias();
                    }
                    else
                    {
                        listaVehiculos.MostrarListaAutos();
                    }
                    nuevaDotacion.AsignarVehiculo();
                    if (listaDotaciones.AgregarDotacion(nuevaDotacion))
                    {
                        Console.WriteLine("Dotacion agregada con exito");
                        nuevaDotacion.MostrarDotacion();
                    }
                    else
                    {
                        Console.WriteLine("La dotacion tiene elementos asignados en otra ya existente, cambie los datos y vuelva a intentarlo");
                    }
                    break;
                case "4":
                    Console.Write("Ingrese Id para buscar empleado: ");
                    ulong IdEmp;
                    //ulong.TryParse( Console.ReadLine() , out IdEmp);
                    while(!ulong.TryParse( Console.ReadLine() , out IdEmp)){
                        Console.WriteLine("Id no válido. Debe ser numérico. Reintentando.");
                        Console.Write("Ingrese Id para buscar empleado: ");
                    }
                    if (listaEmpleados.BuscarEmpleadoPorId(IdEmp))
                    {
                        if (listaDotaciones.ExisteProfesionalesEnDotaciones(IdEmp) || listaDotaciones.ExisteChoferEnDotacion(IdEmp))
                        {
                            listaDotaciones.EmpleadoPorIdEnDotacion(IdEmp);
                        }
                        else Console.WriteLine("El empleado no integra ninguna dotacion.");
                    }


                    Console.Write("\n\tPresione Enter para continuar...");
                    Console.ReadLine();
                    break;
                case "5":
                    listaEmpleados.MostrarListaEmpleados();
                    Console.Write("\n\tPresione Enter para continuar...");
                    Console.ReadLine();
                    break;
                case "6":
                    listaVehiculos.MostrarTodosVehiculos();
                    Console.Write("\n\tPresione Enter para continuar...");
                    Console.ReadLine();
                    break;
                case "7":
                    string selMen;
                    ulong idEmp;
                    Console.WriteLine("Quiere eliminar un chofer o un profesional?");
                    Console.WriteLine("1.Chofer");
                    Console.WriteLine("2.Profesional");
                    Console.Write(">");
                    selMen = Console.ReadLine();
                    switch (selMen)
                    {
                        case "1":
                            while (!ulong.TryParse(Console.ReadLine(), out idEmp)){
                                Console.WriteLine("Ingrese solamente valores numericos en el id");
                            }
                            if (!listaDotaciones.ExisteChoferEnDotacion(idEmp))
                            {
                                listaEmpleados.EliminarChofer(idEmp);
                            }
                            else
                            {
                                Console.WriteLine("El chofer esta asignado a una dotacion");
                            }
                            
                            break;
                        case "2":
                            while (!ulong.TryParse(Console.ReadLine(), out idEmp)){
                                Console.WriteLine("Ingrese solamente valores numericos en el id");
                            }
                            if (!listaDotaciones.ExisteProfesionalesEnDotaciones(idEmp))
                            {
                                listaEmpleados.EliminarProfesional(idEmp);
                            }
                            else
                            {
                                Console.WriteLine("El chofer esta asignado a una dotacion");
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case "8":
                    
                    Console.WriteLine("Ingrese patente de vehiculo: ");
                    listaDotaciones.DarDotacionPorPatente(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("El valor ingresado no es valido, ingrese una opcion del menu.");
                    break;
            }
            MostrarMenu();
        }
    }
}
