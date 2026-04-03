using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using proyecto_2_IPC2.Modelos;

namespace proyecto_2_IPC2.Estructuras
{
    public class NodoInstruccion
    {
        public Instrucciones Dato { get; set; }
        public NodoInstruccion Siguiente { get; set; }

        public NodoInstruccion(Instrucciones instruccion)
        {
            Dato=instruccion;
            Siguiente=null;
        }
    }
}
