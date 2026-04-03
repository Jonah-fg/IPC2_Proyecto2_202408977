using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Estructuras
{
    public class NodoTabla
    {
        public string NombreDron { get; set; }
        public int Altura { get; set; }
        public string Letra { get; set; }
        public NodoTabla Siguiente { get; set; }

        public NodoTabla(string dron, int altura, string letra)
        {
            NombreDron=dron;
            Altura=altura;
            Letra=letra;
            Siguiente =null;
        }
    }
}
