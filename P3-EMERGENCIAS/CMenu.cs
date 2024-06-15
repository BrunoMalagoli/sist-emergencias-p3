using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergencias
{
    public class CMenu
    {
        private static CListaVehiculos listaVehiculos;
        private static CListaEmpleados listaEmpleados;
        private static CListaDotaciones listaDotaciones;
   
        public CMenu()
        {
            listaVehiculos = new CListaVehiculos();
            listaEmpleados = new CListaEmpleados();
            listaDotaciones = new CListaDotaciones();   
        }

        public void MostrarMenu()
        {
            string? opMenu;
            Console.WriteLine("\t==============================");
            Console.WriteLine("\t1.Desea cargar empleados?");
            Console.WriteLine("\t2.Desea cargar vehiculos?");
            Console.WriteLine("\t3.Asignar Dotacion");
            Console.WriteLine("\t4.Buscar empleado por ID");
            Console.WriteLine("\t5.Mostrar todos los empleados");
            Console.WriteLine("\t6.Mostrar todos los vehiculos");
            Console.WriteLine("\t0.Salir");
            Console.WriteLine("\t==============================");
            Console.Write("\t>");
            opMenu = Console.ReadLine();
            if (Convert.ToUInt32(opMenu) != 0 && Convert.ToUInt32(opMenu) <= 6)
            {
                ManejarMenu(opMenu);
            }
            else
            {
                if (opMenu == "0")
                {
                    Console.WriteLine("\n\tHasta la proxima!\n");
                    Console.Write("(presione Enter para finalizar...)");
                    Console.ReadLine();
                }

                else if (Convert.ToUInt32(opMenu) > 6)
                {
                    Console.WriteLine("El valor ingresado no es valido, ingrese una opcion del menu");
                    MostrarMenu();
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
                    ulong.TryParse(Console.ReadLine(), out codIdentPersonal);      //COMPROBACION TRYPARSE      
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
                            uint.TryParse(Console.ReadLine(), out numRegistroConducir);      //COMPROBACION TRYPARSE
                            Console.Write("Distrito de Emision de Registro Conducir : ");
                            distritoEmisionReg = Console.ReadLine();
                            listaEmpleados.CargarChofer(codIdentPersonal, apellido, nombre, numRegistroConducir, distritoEmisionReg);
                            break;
                        case "2":
                            Console.Write("Num Matricula : ");
                            bool parsed = ushort.TryParse(Console.ReadLine(), out numMatricula); //COMPROBACION TRYPARSE
                            while (!parsed){
                                Console.WriteLine("Num Matricula erróneo (supera 65535). Reintentando.");
                                Console.Write("Num Matricula:");
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
                            } while (categoria == null || !parsed);
                            listaEmpleados.CargarProfesional(codIdentPersonal, apellido, nombre, numMatricula, categoria);
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
                        listaVehiculos.CargarAuto(patente, modelo, marca);
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
                            Console.WriteLine("Tipo de ambulancia : ");
                            tipo = Console.ReadLine();
                            Console.Write("Patente : ");
                            patente = Console.ReadLine();
                            Console.Write("Marca : ");
                            marca = Console.ReadLine();
                            Console.Write("Modelo: ");
                            modelo = Console.ReadLine();
                        } while (patente == null || marca == null || modelo == null || tipo == null);
                        listaVehiculos.CargarAmbulancia(patente, modelo, marca, tipo);

                    }
                    break;
                case "3":
                    //Metodo asignar dotacion      
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
                    listaDotaciones.AgregarDotacion(nuevaDotacion);
                    nuevaDotacion.MostrarDotacion();
                    MostrarMenu();
                    break;
                case "4":
                    Console.Write("Ingrese Id para buscar empleado: ");
                    ulong IdEmp;
                    ulong.TryParse( Console.ReadLine() , out IdEmp);
                    listaEmpleados.BuscarEmpleadoPorId(IdEmp);
                    Console.Write("\n\t(presione Enter para continuar)");
                    Console.ReadLine();
                    break;
                case "5":
                    listaEmpleados.MostrarListaEmpleados();
                    Console.Write("\n\t(presione Enter para continuar)");
                    Console.ReadLine();
                    break;
                case "6":
                    listaVehiculos.MostrarTodosVehiculos();
                    Console.Write("\n\t(presione Enter para continuar)");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("\n\tEl valor ingresado no es valido, ingrese una opcion del menú.\n");
                    break;
            }
            MostrarMenu();
        }
    }
}
