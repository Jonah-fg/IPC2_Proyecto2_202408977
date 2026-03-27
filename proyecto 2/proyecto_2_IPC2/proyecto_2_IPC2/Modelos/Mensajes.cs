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
        public ListaAcciones AccionesPorSegundo { get; set; }

        public Mensajes(string nombre, string texto)
        {
            Nombre=nombre;
            TextoOriginal =texto;
            Instrucciones=new ListaInstrucciones();
            AccionesPorSegundo =new ListaAcciones();
            TiempoOptimo =0;
        }

        public string GenerarMensajeRecibido(SistemaDrones sistema)
        {
            string resultado="";

            for (int i = 0; i<Instrucciones.Cantidad(); i++)
            {
                Instrucciones inst=Instrucciones.Obtener(i);

                string letra =sistema.ObtenerLetra(inst.NombreDron, inst.AlturaObjetivo);
                resultado+= letra;
            }
            return resultado;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"\n--- Mensaje: {Nombre} ---");
            Console.WriteLine($"Texto: {TextoOriginal}");
            Console.WriteLine($"Instrucciones ({Instrucciones.Cantidad()}):");

            Instrucciones.MostrarTodosInstrucciones();
            Console.WriteLine($"Tiempo óptimo: {TiempoOptimo} segundos");

            if (AccionesPorSegundo.Cantidad()>0)
            {
                Console.WriteLine("\nAcciones por segundo:");
                AccionesPorSegundo.MostrarTodasAcciones();
            }
        }
    }
}
