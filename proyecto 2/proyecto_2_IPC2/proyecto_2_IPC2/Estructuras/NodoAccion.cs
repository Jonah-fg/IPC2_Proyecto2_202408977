using System;
using System.Collections.Generic;
using System.Text;
using proyecto_2_IPC2.Modelos;

namespace proyecto_2_IPC2.Estructuras
{
    public class NodoAccion
    {
        public AccionPorSegundo Dato { get; set; }
        public NodoAccion Siguiente { get; set; } 

        public NodoAccion(AccionPorSegundo accion)
        {
            Dato=accion;
            Siguiente =null;
        }
    }
}
