using proyecto_2_IPC2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Estructuras
{
    public class NodoSistema
    {
        public SistemaDrones Dato { get; set; }
        public NodoSistema Siguiente { get; set; }

        public NodoSistema(SistemaDrones sistema)
        {
            Dato =sistema;
            Siguiente=null;
        }
    }
}

