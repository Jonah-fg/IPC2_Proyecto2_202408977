using proyecto_2_IPC2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Estructuras
{
    public class ListaAcciones
    {
        public NodoAccion primero { get; private set; }
        private int cantidad;

        public ListaAcciones()
        {
            primero=null;
            cantidad =0;
        }

        public void Agregar(AccionPorSegundo accion)
        {
            NodoAccion nuevo=new NodoAccion(accion);

            if (primero ==null)
            {
                primero=nuevo;
            }
            else
            {
                NodoAccion actual=primero;
                while (actual.Siguiente!= null)
                {
                    actual=actual.Siguiente;
                }
                actual.Siguiente=nuevo;
            }
            cantidad++;
        }

        public void MostrarTodasAcciones()
        {
            NodoAccion actual=primero;
            while (actual !=null)
            {
                Console.WriteLine($"  {actual.Dato}");
                actual=actual.Siguiente;
            }
        }

        public int Cantidad()
        {
            return cantidad;
        }
    }
}
