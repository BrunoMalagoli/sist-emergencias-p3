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
   
        public CMenu()
        {
            listaVehiculos = new CListaVehiculos();
            listaEmpleados = new CListaEmpleados();
        }

        public void MostrarMenu()
        {
            string? opMenu;
            Console.WriteLine("1.Desea cargar empleados?");
            Console.WriteLine("2.Desea cargar vehiculos?");
            Console.WriteLine("3.Asignar Dotacion");
            Console.WriteLine("0.Salir");
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
                }
                Console.WriteLine("El valor ingresado no es valido, ingrese una opcion del menu");
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

                    Console.WriteLine("Ingrese Codigo de Identificacion Personal : ");  //Creacion secuencial cada vez que ingrese uno nuevo o manual por el usuario?
                    ulong.TryParse(Console.ReadLine(), out codIdentPersonal);      //COMPROBACION TRYPARSE      
                    Console.WriteLine("Ingrese Apellido : ");
                    apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese Nombre : ");
                    nombre = Console.ReadLine();
                    Console.WriteLine("Seleccione su ocupacion : ");
                    Console.WriteLine("1. Chofer");
                    Console.WriteLine("2. Profesional");
                    ocupacion = Console.ReadLine();
                    switch (ocupacion)
                    {

                        case "1":
                            Console.WriteLine("Num Registro de Conducir : ");
                            uint.TryParse(Console.ReadLine(), out numRegistroConducir);      //COMPROBACION TRYPARSE
                            Console.WriteLine("Distrito de Emision de Registro Conducir : ");
                            distritoEmisionReg = Console.ReadLine();
                            MostrarMenu();
                            break;
                        case "2":
                            Console.WriteLine("Num Matricula : ");
                            bool parsed = ushort.TryParse(Console.ReadLine(), out numMatricula); //COMPROBACION TRYPARSE
                            do
                            {
                                Console.WriteLine("Seleccione su Categoria : ");
                                Console.WriteLine("1. Medico");
                                Console.WriteLine("2. Enfermero");
                                Console.WriteLine("3. Paramedico");
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
                            MostrarMenu();
                            break;
                            
                    }
                    break;


                case "2":
                    //Metodo carga datos vehiculos (Elegir vehiculo ListaVehiculos)
                    string? opVehiculo;
                    Console.WriteLine("Que tipo de vehiculo desea cargar?");
                    Console.WriteLine("1.Auto");
                    Console.WriteLine("2.Ambulancia");
                    opVehiculo = Console.ReadLine();
                    if (opVehiculo == "1")
                    {
                        Console.WriteLine("Estas cargando un Auto");
                        string? patente;
                        string? modelo;
                        string? marca;
                        do
                        {
                            Console.WriteLine("Patente : ");
                            patente = Console.ReadLine();
                            Console.WriteLine("Marca : ");
                            marca = Console.ReadLine();
                            Console.WriteLine("Modelo: ");
                            modelo = Console.ReadLine();
                        } while (patente == null || marca == null || modelo == null);
                        CListaVehiculos lista = new CListaVehiculos(); // CAMBIAR POR LA LISTA DEL MENU
                        lista.CargarAuto(patente, modelo, marca);
                        lista.MostrarListaAutos();
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
                            Console.WriteLine("Patente : ");
                            patente = Console.ReadLine();
                            Console.WriteLine("Marca : ");
                            marca = Console.ReadLine();
                            Console.WriteLine("Modelo: ");
                            modelo = Console.ReadLine();
                        } while (patente == null || marca == null || modelo == null || tipo == null);
                        CListaVehiculos lista = new CListaVehiculos(); // CAMBIAR POR LA LISTA DEL MENU
                        lista.CargarAmbulancia(patente, modelo, marca, tipo);
                        lista.MostrarListaAmbulancias();

                    }
                    break;
                case "3":
                    //Metodo asignar dotacion
                    break;
                case "4":
                    Console.WriteLine("Ingrese Id para buscar empleado: ");
                    ulong IdEmp;
                    ulong.TryParse( Console.ReadLine() , out IdEmp);
                    listaEmpleados.BuscarEmpleadoPorId(IdEmp);
                    break;
                default:
                    break;
            }
        }
    }
}
