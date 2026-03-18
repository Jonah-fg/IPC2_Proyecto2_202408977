using proyecto_2_IPC2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Estructuras
{
    public class ListaDrones
    {
        private NodoDron primero;
        private int cantidad;

        public ListaDrones()
        {
            primero=null;
            cantidad=0;
        }

        public void Agregar(Dron dron)
        {
            NodoDron nuevo=new NodoDron(dron);

            if (primero==null)
            {
                primero=nuevo;
            }
            else
            {
                NodoDron actual=primero;
                while (actual.Siguiente!=null)
                {
                    actual=actual.Siguiente;
                }
                actual.Siguiente=nuevo;
            }
            cantidad++;
        }

        public Dron Buscar(string nombre)
        {
            NodoDron actual=primero;
            while (actual!=null)
            {
                if (actual.Dato.Nombre==nombre)
                {
                    return actual.Dato;
                }
                actual=actual.Siguiente;
            }
            return null;
        }

        public Dron Obtener(int posicion)
        {
            if (posicion < 0 || posicion >= cantidad)
                return null;

            NodoDron actual = primero;
            for (int i = 0; i<posicion; i++)
            {
                actual = actual.Siguiente;
            }
            return actual.Dato;
        }

        public bool Eliminar(string nombre)
        {
            if (primero==null) return false;

            if (primero.Dato.Nombre==nombre)
            {
                primero=primero.Siguiente;
                cantidad--;
                return true;
            }

            NodoDron actual=primero;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato.Nombre== nombre)
                {
                    actual.Siguiente= actual.Siguiente.Siguiente;
                    cantidad--;
                    return true;
                }
                actual=actual.Siguiente;
            }
            return false;
        }


    }
}
