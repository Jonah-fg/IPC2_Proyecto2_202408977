using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Modelos
{
    public class Instrucciones
    {
        public string NombreDron { get; set; }
        public int AlturaObjetivo { get; set; }
        public string LetraRepresentada { get; set; }

        public Instrucciones(string nombreDron, int alturaObjetivo, string letra)
        {
            NombreDron=nombreDron;
            AlturaObjetivo=alturaObjetivo;
            LetraRepresentada=letra;
        }

        public override string ToString()
        {
            return $"{NombreDron} a {AlturaObjetivo}m -> '{LetraRepresentada}'";
        }
    }
}

