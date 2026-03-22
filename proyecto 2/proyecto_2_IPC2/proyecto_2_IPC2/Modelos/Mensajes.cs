using proyecto_2_IPC2.Estructuras;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Modelos
{
    public class Mensajes
    {
        public string Nombre { get; set; }
        public string TextoOriginal { get; set; }
        public ListaInstrucciones Instrucciones { get; set; }
        public int TiempoOptimo { get; set; }    

    public Mensajes(string nombre, string texto)
        {
            Nombre = nombre;
            TextoOriginal =texto;
            Instrucciones=new ListaInstrucciones();
            TiempoOptimo=0;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"\n--- Mensaje: {Nombre} ---");
            Console.WriteLine($"Texto: {TextoOriginal}");
            Console.WriteLine($"Instrucciones ({Instrucciones.Cantidad()}):");

            Instrucciones.MostrarTodosInstrucciones();
            Console.WriteLine($"Tiempo óptimo: {TiempoOptimo} segundos");
        }
    }
}
