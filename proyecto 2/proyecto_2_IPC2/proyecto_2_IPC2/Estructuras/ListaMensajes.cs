using proyecto_2_IPC2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Estructuras
{
    internal class ListaMensajes
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

        public void MostrarTodosMensajes()
        {
            Console.WriteLine("\n=== LISTA DE MENSAJES ===");
            NodoMensajes actual=primero;
            int i=1;
            while (actual!=null)
            {
                Console.WriteLine($"{i}. {actual.Dato.Nombre} - '{actual.Dato.TextoOriginal}'");
                actual =actual.Siguiente;
                i++;
            }
        }

        public int Cantidad()
        {
            return cantidad;
        }
    }
}
