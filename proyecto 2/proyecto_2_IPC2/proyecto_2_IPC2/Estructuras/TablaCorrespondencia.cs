using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Estructuras
{
    public class TablaCorrespondencia
    {
        private NodoTabla primero;
        private int cantidad;

        public TablaCorrespondencia()
        {
            primero = null;
            cantidad = 0;
        }

        public void Agregar(string nombreDron, int altura, string letra)
        {
            NodoTabla nuevo =new NodoTabla(nombreDron, altura, letra);

            if (primero ==null)
            {
                primero =nuevo;
            }
            else
            {
                NodoTabla actual=primero;
                while (actual.Siguiente != null)
                {
                    actual=actual.Siguiente;
                }
                actual.Siguiente=nuevo;
            }
            cantidad++;
        }

        public string BuscarLetra(string nombreDron, int altura)
        {
            NodoTabla actual=primero;
            while (actual !=null)
            {
                if (actual.NombreDron==nombreDron && actual.Altura == altura)
                {
                    return actual.Letra;
                }
                actual = actual.Siguiente;
            }
            return null; 
        }

        public void MostrarTabla()
        {
            Console.WriteLine("\n=== TABLA DE CORRESPONDENCIA ===");
            Console.WriteLine("Dron\tAltura\tLetra");
            Console.WriteLine("----------------------");

            NodoTabla actual=primero;
            while (actual != null)
            {
                Console.WriteLine($"{actual.NombreDron}\t{actual.Altura}\t{actual.Letra}");
                actual =actual.Siguiente;
            }
        }
    }
}
