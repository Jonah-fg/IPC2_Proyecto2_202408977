using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_IPC2.Modelos
{
    public class AccionPorSegundo
    {
        public int Segundo { get; set; }
        public string NombreDron { get; set; }
        public string TipoAccion { get; set; }

        public AccionPorSegundo(int segundo, string nombreDron, string accion)
        {
            Segundo=segundo;
            NombreDron =nombreDron;
            TipoAccion =accion;
        }

        public override string ToString()
        {
            return $"Segundo {Segundo}: {NombreDron} - {TipoAccion}";
        }
    }
}

