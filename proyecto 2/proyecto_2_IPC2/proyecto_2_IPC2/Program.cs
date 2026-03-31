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
            SistemaDrones sistema=null;
            string opcion = "";

            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE DRONES IPC2 ===\n");
                Console.WriteLine("1. Cargar XML");
                Console.WriteLine("2. Ver drones");
                Console.WriteLine("3. Ver mensajes");
                Console.WriteLine("4. Generar XML salida");
                Console.WriteLine("5. Generar reporte Graphviz");
                Console.WriteLine("6. Ayuda");
                Console.WriteLine("7. Salir");
                Console.Write("\nSeleccione opción: ");

                opcion =Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {

                    case "1":
                        LectorXML lector=new LectorXML();
                        sistema =lector.CargarSistema("entrada.xml");
                        sistema.ProcesarMensajes();
                        Console.WriteLine("XML cargado correctamente");
                        break;


                    case "2":
                        if (sistema ==null)
                        {
                            Console.WriteLine("Debe cargar XML primero");
                            break;
                        }
                        sistema.Drones.MostrarTodosDrones();
                        break;


                    case "3":
                        if (sistema == null)
                        {
                            Console.WriteLine("Debe cargar XML primero");
                            break;
                        }
                        sistema.Mensajes.MostrarTodosMensajes();
                        break;


                    case "4":
                        if (sistema == null)
                        {
                            Console.WriteLine("Debe cargar XML primero");
                            break;
                        }
                        EscritorXML escritor=new EscritorXML();
                        escritor.GenerarSalida(sistema, "salida.xml");
                        Console.WriteLine("Archivo salida.xml generado");
                        break;


                    case "5":
                        if (sistema ==null)
                        {
                            Console.WriteLine("Debe cargar XML primero");
                            break;
                        }
                        ReporteGraphviz reporte = new ReporteGraphviz();
                        reporte.GenerarDot(sistema);
                        reporte.GenerarTablaCorrespondencia(sistema);
                        Console.WriteLine("Archivos .dot generados");
                        break;


                    case "6":
                        Console.WriteLine("Proyecto 2 IPC2");
                        Console.WriteLine("Estudiante: Jonathan Eduardo Fuentes Garcia");
                        Console.WriteLine("Carnet: 202408977");
                        break;

                }
                Console.WriteLine("Presione una tecla...");
                Console.ReadKey();
            }
            while (opcion != "7");
        }
    }
}