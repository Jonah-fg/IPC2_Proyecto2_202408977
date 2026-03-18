using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using proyecto_2_IPC2.Modelos;

namespace proyecto_2_IPC2.Estructuras
{
    public class NodoDron
    {
        public Dron Dato { get; set; }
        public NodoDron Siguiente { get; set; }

        public NodoDron(Dron dron)
        {
            Dato=dron;
            Siguiente=null;
        }
    }
}
