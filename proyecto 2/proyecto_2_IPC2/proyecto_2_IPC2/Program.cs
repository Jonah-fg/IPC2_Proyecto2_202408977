using proyecto_2_IPC2.Estructuras;
using proyecto_2_IPC2.Modelos;
using proyecto_2_IPC2.Servicios;
using System;

namespace IPC2_Proyecto2_TuCarnet
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorDatos gestor = new GestorDatos();
            string opcion = "";

            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE DRONES IPC2 ===\n");
                Console.WriteLine("1. Cargar XML");
                Console.WriteLine("2. Gestión de Drones");
                Console.WriteLine("3. Gestión de Sistemas de Drones");
                Console.WriteLine("4. Gestión de Mensajes");
                Console.WriteLine("5. Generar XML de salida");
                Console.WriteLine("6. Ayuda");
                Console.WriteLine("7. Salir");
                Console.Write("\nSeleccione opción: ");

                opcion = Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese la ruta del archivo XML: ");
                        string ruta = Console.ReadLine();
                        try
                        {
                            LectorXML lector=new LectorXML();
                            lector.CargarConfiguracion(ruta, gestor);
                            gestor.ProcesarTodosMensajes(); 
                            Console.WriteLine("XML cargado correctamente y mensajes procesados.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al cargar XML: {ex.Message}");
                        }
                        break;

                    case "2":
                        GestionDrones(gestor);
                        break;

                    case "3":
                        GestionSistemas(gestor);
                        break;

                    case "4":
                        GestionMensajes(gestor);
                        break;

                    case "5":
                        if (gestor.Mensajes.Cantidad() == 0)
                        {
                            Console.WriteLine("No hay mensajes cargados. Primero cargue un archivo XML.");
                        }
                        else
                        {
                            Console.Write("Nombre del archivo de salida (ej: salida.xml): ");
                            string salida=Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(salida)) salida = "salida.xml";
                            EscritorXML escritor = new EscritorXML();
                            escritor.GenerarSalida(gestor, salida);
                            Console.WriteLine($"Archivo {salida} generado.");
                        }
                        break;

                    case "6":
                        MostrarAyuda();
                        break;

                    case "7":
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion!="7")
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            } while (opcion != "7");
        }



        static void GestionDrones(GestorDatos gestor)
        {
            string subop="";
            do
            {
                Console.Clear();
                Console.WriteLine("--- GESTIÓN DE DRONES ---");
                Console.WriteLine("1. Ver listado ordenado alfabéticamente");
                Console.WriteLine("2. Agregar nuevo dron");
                Console.WriteLine("3. Volver al menú principal");
                Console.Write("Opción: ");
                subop = Console.ReadLine();

                switch (subop)
                {
                    case "1":
                        gestor.Drones.MostrarTodosDrones(); 
                        break;

                    case "2":
                        Console.Write("Nombre del nuevo dron: ");
                        string nombre=Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(nombre))
                        {
                            Console.WriteLine("Nombre no válido.");
                        }
                        else if (gestor.Drones.Buscar(nombre) != null)
                        {
                            Console.WriteLine("Ya existe un dron con ese nombre.");
                        }
                        else
                        {
                            gestor.Drones.Agregar(new Dron(nombre));
                            Console.WriteLine("Dron agregado correctamente.");
                        }
                        break;

                    case "3":
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (subop != "3")
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            } while (subop != "3");
        }


        static void GestionSistemas(GestorDatos gestor)
        {
            string subop = "";
            do
            {
                Console.Clear();
                Console.WriteLine("--- GESTIÓN DE SISTEMAS DE DRONES ---");
                Console.WriteLine("1. Ver listado de sistemas");
                Console.WriteLine("2. Ver gráficamente (Graphviz) listado de sistemas");
                Console.WriteLine("3. Volver al menú principal");
                Console.Write("Opción: ");
                subop = Console.ReadLine();

                switch (subop)
                {
                    case "1":
                        gestor.Sistemas.MostrarTodosSistemas(); 
                        break;

                    case "2":
                        if (gestor.Sistemas.Cantidad()== 0)
                        {
                            Console.WriteLine("No hay sistemas cargados.");
                        }
                        else
                        {
                            ReporteGraphviz reporte = new ReporteGraphviz();
                            reporte.GenerarReporteSistemas(gestor.Sistemas);
                            Console.WriteLine("Archivo 'sistemas.dot' generado. Use Graphviz para visualizar.");
                        }
                        break;

                    case "3":
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (subop !="3")
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            } while (subop != "3");
        }

        static void GestionMensajes(GestorDatos gestor)
        {
            string subop ="";
            do
            {
                Console.Clear();
                Console.WriteLine("--- GESTIÓN DE MENSAJES ---");
                Console.WriteLine("1. Ver listado de mensajes (ordenado alfabéticamente)");
                Console.WriteLine("2. Ver instrucciones para enviar un mensaje");
                Console.WriteLine("3. Volver al menú principal");
                Console.Write("Opción: ");
                subop = Console.ReadLine();

                switch (subop)
                {
                    case "1":
                        gestor.Mensajes.MostrarTodosOrdenados(); 
                        break;

                    case "2":
                        if (gestor.Mensajes.Cantidad() == 0)
                        {
                            Console.WriteLine("No hay mensajes cargados.");
                            break;
                        }
                        Console.Write("Ingrese el nombre del mensaje: ");
                        string nombre=Console.ReadLine();
                        Mensajes mensaje =gestor.Mensajes.Buscar(nombre);
                        if (mensaje ==null)
                        {
                            Console.WriteLine("Mensaje no encontrado.");
                        }
                        else
                        {
                            SistemaDrones sistema=gestor.Sistemas.Buscar(mensaje.NombreSistema);
                            Console.WriteLine($"\n--- Detalles del mensaje '{mensaje.Nombre}' ---");
                            Console.WriteLine($"Sistema de drones: {mensaje.NombreSistema} (Altura máxima: {(sistema != null ? sistema.AlturaMaxima.ToString() : "desconocida")})");
                            Console.WriteLine($"Mensaje a enviar: {mensaje.TextoOriginal}");
                            Console.WriteLine($"Tiempo óptimo: {mensaje.TiempoOptimo} segundos");
                            Console.WriteLine("\nInstrucciones:");
                            mensaje.Instrucciones.MostrarTodosInstrucciones();

                            ReporteGraphviz reporte =new ReporteGraphviz();
                            reporte.GenerarDotMensaje(mensaje, $"mensaje_{mensaje.Nombre}.dot");
                            Console.WriteLine($"\nGráfico generado: mensaje_{mensaje.Nombre}.dot");
                        }
                        break;

                    case "3":
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (subop!= "3")
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            } while (subop != "3");
        }

        static void MostrarAyuda()
        {
            Console.WriteLine("=== AYUDA DEL PROYECTO ===");
            Console.WriteLine("Proyecto No. 2 - IPC2");
            Console.WriteLine("Estudiante: Jonathan Eduardo Fuentes Garcia");
            Console.WriteLine("Carnet: 202408977");
            Console.WriteLine("\nDocumentación completa disponible en el repositorio.");
            Console.WriteLine("Link: https://github.com/tu-usuario/IPC2_Proyecto2_202408977"); 
        }
    }
}
