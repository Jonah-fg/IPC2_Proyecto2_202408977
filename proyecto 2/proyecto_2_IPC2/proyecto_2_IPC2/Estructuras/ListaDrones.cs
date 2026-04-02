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
            OrdenarAlfabeticamente();
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
            if (posicion < 0 || posicion>= cantidad)
                return null;

            NodoDron actual = primero;
            for (int i = 0; i<posicion; i++)
            {
                actual=actual.Siguiente;
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

        public void MostrarTodosDrones()
        {
            OrdenarAlfabeticamente();
            Console.WriteLine("\n=== LISTA DE DRONES ===");
            NodoDron actual=primero;
            int i =1;
            while (actual !=null)
            {
                Console.WriteLine($"{i}. {actual.Dato}");
                actual =actual.Siguiente;
                i++;
            }
            Console.WriteLine($"Total: {cantidad} drones");
        }

        public void OrdenarAlfabeticamente()
        {
            if (cantidad <=1)
                return;

            bool intercambio;
            do
            {
                intercambio=false;
                NodoDron actual =primero;

                while (actual != null && actual.Siguiente != null)
                {
                    if (string.Compare(actual.Dato.Nombre, actual.Siguiente.Dato.Nombre) > 0)
                    {
                        Dron temp =actual.Dato;
                        actual.Dato= actual.Siguiente.Dato;
                        actual.Siguiente.Dato= temp;
                        intercambio= true;
                    }
                    actual =actual.Siguiente;
                }
            }
            while (intercambio);
        }

        public NodoDron ObtenerPrimero()
        {
            return primero;
        }

        public int Cantidad()
        {
            return cantidad;
        }
    }
}
