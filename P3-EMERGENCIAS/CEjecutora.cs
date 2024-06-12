using System;

namespace Emergencias
{
    public class CEjecutora
    {
        private static void ManejarMenu(string selMenu)
        {
            switch (selMenu)
            {
                case "1":
                    //Metodo carga datos empleados
                    break;
                case "2":
                    //Metodo carga datos vehiculos (Elegir vehiculo ListaVehiculos)
                    string opVehiculo;
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
                        } while (patente == null || marca == null ||  modelo == null);
                        CListaVehiculos lista = new CListaVehiculos();
                        lista.CargarAuto(patente, modelo, marca);
                        lista.MostrarListaAutos();
                    }
                    else if(opVehiculo == "2")
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
                        CListaVehiculos lista = new CListaVehiculos();
                        lista.CargarAmbulancia(patente, modelo, marca , tipo);
                        lista.MostrarListaAmbulancias();

                    }
                    break;
                case "3":
                    //Metodo asignar dotacion
                    break;
                default:
                break;
            }
        } 
        private static void MostrarMenu()
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

        public static void Main()
        {
            MostrarMenu();
        }
    }
}

