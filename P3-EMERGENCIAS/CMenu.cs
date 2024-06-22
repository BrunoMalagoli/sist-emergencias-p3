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
            Console.Clear();
            Console.WriteLine("\t===============================");
            Console.WriteLine("\t1.Desea cargar empleados?");
            Console.WriteLine("\t2.Desea cargar vehiculos?");
            Console.WriteLine("\t3.Asignar Dotacion");
            Console.WriteLine("\t4.Buscar empleado por ID");
            Console.WriteLine("\t5.Mostrar todos los empleados");
            Console.WriteLine("\t6.Mostrar todos los vehiculos");
            Console.WriteLine("\t7.Eliminar empleado por id");
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
                    Console.WriteLine("\tHasta la proxima!");
                    Console.WriteLine("\tPresione Enter para finalizar...");
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

                    Console.Write("\tIngrese Codigo de Identificacion Personal : ");  //Creacion secuencial cada vez que ingrese uno nuevo o manual por el usuario?
                    //ulong.TryParse(Console.ReadLine(), out codIdentPersonal);      //COMPROBACION TRYPARSE  
                    while(!ulong.TryParse(Console.ReadLine(), out codIdentPersonal))//COMPROBACION TRYPARSE  
                    {
                        Console.WriteLine("\tEl código ingresado no es válido, debe ser numérico. Reintentando.");
                        Console.Write("\tIngrese Codigo de Identificacion Personal : ");

                    }
                    Console.Write("\tIngrese Apellido : ");
                    apellido = Console.ReadLine();
                    Console.Write("\tIngrese Nombre : ");
                    nombre = Console.ReadLine();
                    Console.WriteLine("\tSeleccione su ocupacion : ");
                    Console.WriteLine("\t\t1. Chofer");
                    Console.WriteLine("\t\t2. Profesional");
                    Console.Write("\t>");
                    ocupacion = Console.ReadLine();
                    switch (ocupacion)
                    {

                        case "1":
                            Console.Write("\tNum Registro de Conducir : ");
                            while(!uint.TryParse(Console.ReadLine(), out numRegistroConducir)) //COMPROBACION TRYPARSE
                            { 
                                Console.WriteLine("\tRegistro de conducir no válido. Debe ser numérico. Reintentando.");
                                Console.Write("\tNum Registro de Conducir : ");
                            }
                            //uint.TryParse(Console.ReadLine(), out numRegistroConducir);      //COMPROBACION TRYPARSE
                            Console.Write("\tDistrito de Emision de Registro Conducir : ");
                            distritoEmisionReg = Console.ReadLine();
                            listaEmpleados.CargarChofer(codIdentPersonal, apellido, nombre, numRegistroConducir, distritoEmisionReg);
                            break;
                        case "2":
                            Console.Write("\tNum Matricula : ");
                            bool parsed = ushort.TryParse(Console.ReadLine(), out numMatricula); //COMPROBACION TRYPARSE
                            while(!parsed){
                                Console.WriteLine("\tNúmero de Matrícula erróneo (supera 65535). Reintentando.");
                                Console.Write("\tNum Matrícula: ");
                                parsed = ushort.TryParse(Console.ReadLine(), out numMatricula); //NUEVA COMPROBACION TRYPARSE
                            }

                            do
                            {
                                Console.WriteLine("\tSeleccione su Categoria : ");
                                Console.WriteLine("\t\t1. Medico");
                                Console.WriteLine("\t\t2. Enfermero");
                                Console.WriteLine("\t\t3. Paramedico");
                                Console.Write("\t>");
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
                                Console.WriteLine("\tProfesional agregado correctamente");
                                
                            }
                            else
                            {
                                Console.WriteLine("\tEl Profesional ya existe en la lista");
                                
                            }
                            break;
                            
                    }
                    break;


                case "2":
                    //Metodo carga datos vehiculos (Elegir vehiculo ListaVehiculos)
                    string? opVehiculo;
                    Console.WriteLine("\tQue tipo de vehiculo desea cargar?");
                    Console.WriteLine("\t\t1.Auto");
                    Console.WriteLine("\t\t2.Ambulancia");
                    Console.Write("\t>");
                    opVehiculo = Console.ReadLine();
                    if (opVehiculo == "1")
                    {
                        Console.WriteLine("\tEstas cargando un Auto");
                        string? patente;
                        string? modelo;
                        string? marca;
                        do
                        {
                            Console.Write("\tPatente : ");
                            patente = Console.ReadLine();
                            Console.Write("\tMarca : ");
                            marca = Console.ReadLine();
                            Console.Write("\tModelo: ");
                            modelo = Console.ReadLine();
                        } while (patente == null || marca == null || modelo == null);
                        
                        if (listaVehiculos.CargarAuto(patente, modelo, marca))
                        {
                            Console.WriteLine("\tAuto cargado correctamente");
                        }
                        else
                        {
                            Console.WriteLine("\tEl auto ya existe en el programa");
                            Console.WriteLine("\tPulse enter para continuar...");
                            Console.Read();
                        }
                    }
                    else if (opVehiculo == "2")
                    {
                        Console.WriteLine("\tEstas cargando una Ambulancia");
                        string? patente;
                        string? modelo;
                        string? marca;
                        string? tipo; 
                        do
                        {
                            Console.Write("\tTipo de ambulancia: ");
                            Console.WriteLine("1.EMG  2.UTIM  3.UCM");
                            Console.Write("\t>");
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
                                    Console.WriteLine("\tTipo de ambulancia invalido , intentelo nuevamente");
                                    MostrarMenu();
                                    break;
                            }  
                            Console.Write("\tPatente : ");
                            patente = Console.ReadLine();
                            Console.Write("\tMarca : ");
                            marca = Console.ReadLine();
                            Console.Write("\tModelo: ");
                            modelo = Console.ReadLine();
                        } while (patente == null || marca == null || modelo == null || tipo == null);
                        if(listaVehiculos.CargarAmbulancia(patente, modelo, marca, tipo))
                        {
                            Console.WriteLine("\tAmbulancia cargada correctamente");
                        }
                        else
                        {
                            Console.WriteLine("\tLa ambulancia ya existe en el programa");
                            Console.WriteLine("\tPulse enter para continuar...");
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
                        Console.WriteLine("\tDotacion agregada con exito!!!");
                        nuevaDotacion.MostrarDotacion();
                    }
                    else
                    {
                        Console.WriteLine("\tLa dotacion tiene elementos asignados en otra ya existente, cambie los datos y vuelva a intentarlo");
                    }
                    break;
                case "4":
                    Console.Write("\tIngrese Id para buscar empleado: ");
                    ulong IdEmp;
                    //ulong.TryParse( Console.ReadLine() , out IdEmp);
                    while(!ulong.TryParse( Console.ReadLine() , out IdEmp)){
                        Console.WriteLine("\tId no válido. Debe ser numérico. Reintentando.");
                        Console.Write("\tIngrese Id para buscar empleado: ");
                    }
                    listaEmpleados.BuscarEmpleadoPorId(IdEmp);
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
                    Console.WriteLine("\tQuiere eliminar un chofer o un profesional?");
                    Console.WriteLine("\t\t1.Chofer");
                    Console.WriteLine("\t\t2.Profesional");
                    Console.Write("\t>");
                    selMen = Console.ReadLine();
                    Console.WriteLine("\t{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}", "ID", "APELLIDO", "NOMBRE", "MAT/REG", "CAT/DIST");
                    switch (selMen)
                    {                      
                            case "1":
                      
                            listaEmpleados.MostrarChoferes();
                            Console.Write("\n\tIngrese el ID para eliminar: ");
                            while (!ulong.TryParse(Console.ReadLine(), out idEmp)){
                                Console.WriteLine("\tIngrese solamente valores numericos en el id");
                            }
                            if (!listaDotaciones.ExisteChoferEnDotacion(idEmp))
                            {
                                listaEmpleados.EliminarChofer(idEmp);
                            }
                            else
                            {
                                Console.WriteLine("\tEl chofer esta asignado a una dotacion");
                                Console.Write("\n\tPresione Enter para continuar...");
                                Console.ReadLine();
                            }
                            
                            break;
                        case "2":
                            listaEmpleados.MostrarProfesionales();
                            Console.Write("\n\tIngrese el ID para eliminar: ");
                            while (!ulong.TryParse(Console.ReadLine(), out idEmp)){
                                Console.WriteLine("\tIngrese solamente valores numericos en el id");
                            }
                            if (!listaDotaciones.ExisteProfesionalesEnDotaciones(idEmp))
                            {
                                listaEmpleados.EliminarProfesional(idEmp);

                            }
                            else
                            {
                                Console.WriteLine("\tEl chofer esta asignado a una dotacion");
                                Console.Write("\n\tPresione Enter para continuar...");
                                Console.ReadLine();
                            }
                            break;
                        default:

                            Console.Write("\n\tIngreso una opcion invalida. Vuelva a intentarlo..");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("\tEl valor ingresado no es valido, ingrese una opcion del menu.");
                    break;
            }
            MostrarMenu();
        }
    }
}
