using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using proyecto_2_IPC2.Modelos;

namespace proyecto_2_IPC2.Estructuras
{
    public class NodoMensajes
    {
        public Mensajes Dato { get; set; }
        public NodoMensajes Siguiente { get; set; }

        public NodoMensajes(Mensajes mensaje)
        {
            Dato = mensaje;
            Siguiente =null;
        }
    }
}
