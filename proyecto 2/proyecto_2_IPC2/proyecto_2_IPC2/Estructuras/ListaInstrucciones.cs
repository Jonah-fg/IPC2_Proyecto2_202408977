using proyecto_2_IPC2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Estructuras
{
    public class ListaInstrucciones
    {
        private NodoInstruccion primero;
        private int cantidad;

        public ListaInstrucciones()
        {
            primero=null;
            cantidad=0;
        }

        public void Agregar(Instrucciones instruccion)
        {
            NodoInstruccion nuevo=new NodoInstruccion(instruccion);
            if (primero==null)
            {
                primero=nuevo;
            }
            else
            {
                NodoInstruccion actual=primero;
                while (actual.Siguiente != null)
                {
                    actual=actual.Siguiente;
                }
                actual.Siguiente =nuevo;
            }
            cantidad++;
        }

        public Instrucciones Obtener(int posicion)
        {
            if (posicion < 0 || posicion>= cantidad)
                return null;

            NodoInstruccion actual=primero;
            for (int i =0; i<posicion; i++)
            {
                actual=actual.Siguiente;
            }
            return actual.Dato;
        }

        public void MostrarTodosInstrucciones()
        {
            NodoInstruccion actual=primero;
            int i=1;
            while (actual!= null)
            {
                Console.WriteLine($"  {i}. {actual.Dato}");
                actual=actual.Siguiente;
                i++;
            }
        }

        public bool Eliminar(int posicion)
        {
            if (posicion < 0 || posicion >= cantidad)
                return false;

            if (posicion ==0)
            {
                primero=primero.Siguiente;
                cantidad--;
                return true;
            }

            NodoInstruccion actual = primero;
            for (int i = 0; i<posicion - 1; i++)
            {
                actual =actual.Siguiente;
            }

            actual.Siguiente = actual.Siguiente?.Siguiente;
            cantidad--;
            return true;
        }

        public int Cantidad()
        {
            return cantidad;
        }
    }
}
