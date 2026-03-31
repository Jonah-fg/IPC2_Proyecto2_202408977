using proyecto_2_IPC2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Estructuras
{
    public class ListaMensajes
    {
        private NodoMensajes primero;
        private int cantidad;

        public ListaMensajes()
        {
            primero =null;
            cantidad=0;
        }

        public void Agregar(Mensajes mensaje)
        {
            NodoMensajes nuevo=new NodoMensajes(mensaje);

            if (primero==null)
            {
                primero =nuevo;
            }
            else
            {
                NodoMensajes actual=primero;
                while (actual.Siguiente != null)
                {
                    actual=actual.Siguiente;
                }
                actual.Siguiente=nuevo;
            }
            cantidad++;
        }

        public Mensajes Buscar(string nombre)
        {
            NodoMensajes actual=primero;
            while (actual !=null)
            {
                if (actual.Dato.Nombre==nombre)
                {
                    return actual.Dato;
                }
                actual=actual.Siguiente;
            }
            return null;
        }

        public Mensajes Obtener(int indice)
        {
            NodoMensajes actual=primero;
            int contador=0;

            while (actual!= null)
            {
                if (contador == indice)
                {
                    return actual.Dato;
                }
                contador++;
                actual=actual.Siguiente;
            }
            return null;
        }

        public int Cantidad()
        {
            int contador=0;
            NodoMensajes actual= primero;

            while (actual!=null)
            {
                contador++;
                actual= actual.Siguiente;
            }
            return contador;
        }

        public void MostrarTodosMensajes()
        {
            Console.WriteLine("\n=== LISTA DE MENSAJES ===\n");

            NodoMensajes actual= primero;
            int contador = 1;

            while (actual != null)
            {
                Mensajes m = actual.Dato;

                Console.WriteLine("Mensaje: " + m.Nombre);
                Console.WriteLine("\nTexto: " + m.TextoOriginal);
                Console.WriteLine("\nTiempo óptimo: " +m.TiempoOptimo +" segundos");
                Console.WriteLine("\nAcciones por segundo:\n");

                if (m.AccionesPorSegundo != null)
                {
                    m.AccionesPorSegundo.MostrarTodasAcciones();
                }
                Console.WriteLine("\n---------------------\n");
                contador++;
                actual= actual.Siguiente;
            }
        }
    }
}
