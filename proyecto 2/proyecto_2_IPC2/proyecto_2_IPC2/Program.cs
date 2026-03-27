using proyecto_2_IPC2.Estructuras;
using proyecto_2_IPC2.Modelos;
using System;

namespace IPC2_Proyecto2_TuCarnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SIMULADOR DE DRONES IPC2 ===\n");

            SistemaDrones sistema =new SistemaDrones("Sistema1", 5);

            sistema.Drones.Agregar(new Dron("DronX"));
            sistema.Drones.Agregar(new Dron("DronY"));

            sistema.Drones.Agregar(new Dron("DronZ"));

//tabla correspondencia

            sistema.Tabla.Agregar("DronX", 2, "I");
            sistema.Tabla.Agregar("DronY", 3, "P");
            sistema.Tabla.Agregar("DronZ", 2, "C");
            sistema.Tabla.Agregar("DronY", 1, "2");

            Mensajes mensaje =new Mensajes("Mensaje1", "IPC2");

            mensaje.Instrucciones.Agregar(new Instrucciones("DronX",2, ""));
            mensaje.Instrucciones.Agregar(new Instrucciones("DronY", 3, ""));
            mensaje.Instrucciones.Agregar(new Instrucciones("DronZ", 2, ""));
            mensaje.Instrucciones.Agregar(new Instrucciones("DronY", 1, ""));

            SimuladorTiempo simulador =new SimuladorTiempo();

            ResultadoSimulacion resultado =simulador.Simular(sistema.Drones, mensaje.Instrucciones);
            mensaje.TiempoOptimo =resultado.TiempoOptimo;
            mensaje.AccionesPorSegundo =resultado.Acciones;

            string mensajeRecibido=mensaje.GenerarMensajeRecibido(sistema);

            Console.WriteLine("Sistema usado: " + sistema.Nombre);
            Console.WriteLine("Mensaje esperado: " +mensaje.TextoOriginal);
            Console.WriteLine("Mensaje recibido: "+ mensajeRecibido);
            Console.WriteLine("\nTiempo óptimo: " + mensaje.TiempoOptimo + " segundos\n");
            Console.WriteLine("=== ACCIONES POR SEGUNDO ===\n");

            mensaje.AccionesPorSegundo.MostrarTodasAcciones();
            Console.ReadKey();
        }
    }
}