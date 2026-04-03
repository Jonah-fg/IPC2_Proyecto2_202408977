using proyecto_2_IPC2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Estructuras
{
    public class ListaSistemas
    {
        private NodoSistema primero;
        private int cantidad;

        public ListaSistemas()
        {
            primero =null;
            cantidad = 0;
        }

        public void Agregar(SistemaDrones sistema)
        {
            NodoSistema nuevo =new NodoSistema(sistema);
            if (primero==null)
                primero =nuevo;
            else
            {
                NodoSistema actual=primero;
                while (actual.Siguiente!= null)
                    actual= actual.Siguiente;
                actual.Siguiente=nuevo;
            }
            cantidad++;
        }

        public SistemaDrones Buscar(string nombre)
        {
            NodoSistema actual= primero;
            while (actual != null)
            {
                if (actual.Dato.Nombre == nombre)
                    return actual.Dato;
                actual = actual.Siguiente;
            }
            return null;
        }

        public SistemaDrones Obtener(int indice)
        {
            if (indice < 0 || indice >= cantidad) 
                return null;

            NodoSistema actual=primero;
            for (int i = 0; i<indice; i++)
                actual = actual.Siguiente;
            return actual.Dato;
        }

        public void MostrarTodosSistemas()
        {
            Console.WriteLine("\n=== SISTEMAS DE DRONES ===");
            NodoSistema actual=primero;
            int i=1;
            while (actual!=null)
            {
                Console.WriteLine($"{i}. {actual.Dato.Nombre} (Altura máxima: {actual.Dato.AlturaMaxima}m)");
                actual =actual.Siguiente;
                i++;
            }
            Console.WriteLine($"Total: {cantidad} sistemas");
        }

        public NodoSistema ObtenerPrimero() => primero;
        public int Cantidad() => cantidad;
    }
}
