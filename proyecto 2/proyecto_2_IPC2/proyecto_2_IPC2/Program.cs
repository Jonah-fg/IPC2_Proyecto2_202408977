using proyecto_2_IPC2.Estructuras;
using proyecto_2_IPC2.Modelos;
using System;

namespace IPC2_Proyecto2_TuCarnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE CONTROL DE DRONES - IPC2 ===");
            Console.WriteLine("=== SISTEMA DE CONTROL DE DRONES - IPC2 ===\n");

            // 1. Probar ListaDrones
            Console.WriteLine("--- Creando lista de drones (TDA propio) ---");
            ListaDrones listaDrones=new ListaDrones();

            listaDrones.Agregar(new Dron("Dron01"));
            listaDrones.Agregar(new Dron("Dron04"));
            listaDrones.Agregar(new Dron("Dron02"));
            listaDrones.Agregar(new Dron("Dron03"));

            Console.WriteLine("Drones sin ordenar:");
            listaDrones.MostrarTodosDrones();
            listaDrones.MostrarTodosDrones();

            Console.WriteLine("\nOrdenando alfabéticamente...");
            listaDrones.OrdenarAlfabeticamente();
            listaDrones.MostrarTodosDrones();

            Console.WriteLine("\n--- Creando tabla de correspondencia ---");
            TablaCorrespondencia tabla=new TablaCorrespondencia();

            tabla.Agregar("Dron01", 8, " ");  
            tabla.Agregar("Dron01", 3, "H");
            tabla.Agregar("Dron02", 4, "E");
            tabla.Agregar("Dron03", 4, "L");
            tabla.Agregar("Dron04", 4, "L");
            tabla.Agregar("Dron03", 5, "O");

            tabla.MostrarTabla();

            Console.WriteLine("\n--- Probando búsqueda en tabla ---");
            string letra=tabla.BuscarLetra("Dron03", 5);
            Console.WriteLine($"Dron03 a 5m representa: '{letra}'");

            Console.WriteLine("\n--- Creando instrucciones para un mensaje ---");
            ListaInstrucciones instrucciones = new ListaInstrucciones();

            instrucciones.Agregar(new Instrucciones("Dron01", 3, "H"));
            instrucciones.Agregar(new Instrucciones("Dron04", 4, "E"));
            instrucciones.Agregar(new Instrucciones("Dron03", 4, "L"));
            instrucciones.Agregar(new Instrucciones("Dron02", 4, "L"));
            instrucciones.Agregar(new Instrucciones("Dron03", 5, "O"));

            Console.WriteLine("Instrucciones del mensaje:");
            instrucciones.MostrarTodosInstrucciones();

            Console.WriteLine("\n--- Creando mensaje completo ---");
            Mensajes mensaje = new Mensajes("Saludo", "HELLO");

            mensaje.Instrucciones.Agregar(new Instrucciones("Dron01", 3, "H"));
            mensaje.Instrucciones.Agregar(new Instrucciones("Dron04", 4, "E"));
            mensaje.Instrucciones.Agregar(new Instrucciones("Dron03", 4, "L"));
            mensaje.Instrucciones.Agregar(new Instrucciones("Dron02", 4, "L"));
            mensaje.Instrucciones.Agregar(new Instrucciones("Dron03", 5, "O"));

            mensaje.MostrarInformacion();

            Console.WriteLine("\n--- Creando lista de mensajes ---");
            ListaMensajes listaMensajes = new ListaMensajes();
            listaMensajes.Agregar(mensaje);

            Mensajes mensaje2 = new Mensajes("Despedida", "BYE");
            mensaje2.Instrucciones.Agregar(new Instrucciones("Dron02", 2, "B"));
            mensaje2.Instrucciones.Agregar(new Instrucciones("Dron04", 7, "Y"));
            mensaje2.Instrucciones.Agregar(new Instrucciones("Dron01", 5, "E"));
            listaMensajes.Agregar(mensaje2);

            listaMensajes.MostrarTodosMensajes();

            Console.WriteLine("\nTodo funcionando con TDAS popios (sin genéricos ni arrays)!");
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }

}
